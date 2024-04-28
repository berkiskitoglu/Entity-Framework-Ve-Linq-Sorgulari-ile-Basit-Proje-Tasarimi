using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {

            LblToplamKategoriSayisi.Text = db.Tbl_Kategoriler.Count().ToString();
            LblUrunSayisi.Text = db.Tbl_Urunler.Count().ToString();
            LblAktifMusteriSayisi.Text = db.Tbl_Musteriler.Count(x => x.Durum == true).ToString();
            LblPasifMusteriSayisi.Text = db.Tbl_Musteriler.Count(x => x.Durum == false).ToString();
            LblToplamStokSayisi.Text = db.Tbl_Urunler.Sum(x => x.Stok).ToString();
            LblKasadakiTutar.Text = db.Tbl_Satislar.Sum(x => x.Fiyat).ToString() + " TL";
            LblEnYuksekFiyatliUrun.Text = (from x in db.Tbl_Urunler orderby x.Fiyat descending select x.UrunAd).FirstOrDefault();
            LblEnDusuKFiyatliUrun.Text = (from x in db.Tbl_Urunler orderby x.Fiyat ascending select x.UrunAd).FirstOrDefault();
            LblBeyazEsyaSayisi.Text = db.Tbl_Urunler.Count(x => x.Kategori == 1).ToString();
            LblToplamBuzdolabiSayisi.Text = db.Tbl_Urunler.Count(x => x.UrunAd == "Buzdolabı").ToString();
            LblSehirSayisi.Text = (from x in db.Tbl_Musteriler select x.Sehir).Distinct().Count().ToString();
            LblEnFazlaUrunluMarka.Text = db.MARKAGETIR().FirstOrDefault();

        }
    }
}

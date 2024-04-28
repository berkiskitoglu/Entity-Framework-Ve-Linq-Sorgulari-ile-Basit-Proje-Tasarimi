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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urunler
                                        select new
                                        {
                                            x.UrunID,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.Tbl_Kategoriler.Ad,
                                            x.Durum,
                                        }).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urunler t = new Tbl_Urunler();
            t.UrunAd = TxtUrunAd.Text;
            t.Marka = TxtMarka.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(TxtFiyat.Text);
            t.Durum = true;
            db.Tbl_Urunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürünler Başarıyla Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.Tbl_Urunler.Find(x);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı Bir Şekilde Yapıldı");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.Tbl_Urunler.Find(x);
            urun.UrunAd = TxtUrunAd.Text;
            urun.Stok = short.Parse(TxtStok.Text);
            urun.Marka = TxtMarka.Text;
            urun.Fiyat = int.Parse(TxtFiyat.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategoriler
                               select new
                               {
                                   x.ID,
                                   x.Ad
                               }
                               ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}

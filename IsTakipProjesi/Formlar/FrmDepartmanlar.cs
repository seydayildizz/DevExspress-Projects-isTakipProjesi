using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IsTakipProjesi.Entity;
namespace IsTakipProjesi.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }
        //crud --> create read update delete işlemleri demektir
        DBisTakipEntities db = new DBisTakipEntities();
        void Listele()
        {
            
            //tablo içerisinde yalnızca almak istediğimiz alanlar için bu şekilde tanımlanır
            var degerler = (from x in db.TblDepartmanlar
                           select new
                           {
                               x.ID,
                               x.Ad
                           }).ToList();
            gridControl1.DataSource = degerler;
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            //text den aldığı veriyi t nesnesine ekler
            t.Ad = txtAd.Text;
            //db de departmanlar tablosuna t nesnesini ekler
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı şekilde kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();

        }
    }
}

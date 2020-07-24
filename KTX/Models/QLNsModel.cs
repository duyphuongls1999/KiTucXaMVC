﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class QLNsModel
    {
        [Key]
        [Required(ErrorMessage = "Mã nước không được trống")]
        [Display(Name = "Mã nước")]
        public string MaNuoc { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mã phòng")]
        [StringLength(15)]

        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập ngày")]
        [Display(Name = "Ngày ghi")]
        public DateTime NgayGhi { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập CSD")]
        [Display(Name = "Chỉ số đầu")]
        public int CSD { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập CSC")]
        [Display(Name = "Chỉ số cuối")]

        public int CSC { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập đơn giá")]
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        public double ThanhTienN
        {
            get
            {
                return (CSC - CSD) * DonGia;
            }
        }
        public virtual PHONG PHONG { get; set; }
        private DBKTX db;

        public QLNsModel()
        {
            db = new DBKTX();
        }
        public String Insert(NUOC entityNuoc)
        {
            db.NUOCs.Add(entityNuoc);
            try { db.SaveChanges(); }
            catch (Exception e)
            {
                Console.WriteLine("Mã phòng không có trong CSDL!", e.Message);
            }
            return entityNuoc.MaNuoc;
        }

        public bool Update(NUOC entityNuoc)
        {
            try
            {
                var nuoc = db.NUOCs.Select(x => x).Where(x => x.MaNuoc == entityNuoc.MaNuoc).FirstOrDefault();

                nuoc.MaPhong = entityNuoc.MaPhong;
                nuoc.NgayGhi = entityNuoc.NgayGhi;
                nuoc.CSD = entityNuoc.CSD;
                nuoc.CSC = entityNuoc.CSC;
                nuoc.DonGia = entityNuoc.DonGia;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Sửa không thành công vui lòng kiểm tra lại!", e.Message);
                return false;
            }
            return true;
        }

        public NUOC getByMaNuoc(string MaNuoc)
        {
            return db.NUOCs.SingleOrDefault(x => x.MaNuoc == MaNuoc);
        }

        public NUOC Find(string MaNuoc)
        {
            return db.NUOCs.Find(MaNuoc);

        }

        public List<NUOC> ListAll()
        {
            return db.NUOCs.ToList();
        }
        public List<NUOC> ListWhereAll(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return db.NUOCs.Where(x => x.MaPhong.Contains(searchString)).ToList();
            return db.NUOCs.ToList();

        }
        public void Delete(string maNuoc)
        {
            try
            {

                var nuoc = db.NUOCs.FirstOrDefault(x => x.MaNuoc.Contains(maNuoc));
                if (nuoc != null)
                {
                    db.NUOCs.Remove(nuoc);
                    db.SaveChanges();


                }


            }

            catch (Exception e)
            {
                Console.WriteLine("Xóa không thành công vui lòng kiểm tra lại!", e.Message);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Core.Models
{
    public class Product
    {
        [Display(Name = "Mã Sản Phẩm")]// tương ứng vs bảng product trong database
        [Key]
        [Column("MaSanPham")]
        public int Id { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Column("TenSanPham")]
        public string Name { get; set; }

        [Display(Name = "Giá Sản Phẩm")]
        [Column("GiaSanPham")]
        public double Price { get; set; }

        [Display(Name = "Mô Tả Sản Phẩm")]
        [Column("MoTaSanPham")]
        public string Description { get; set; }
    }
}
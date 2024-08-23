using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public partial class Staff
{
	//[Required(ErrorMessage = "Không được bỏ trống.")]
	public byte? Status { get; set; }
	//[Required(ErrorMessage = "Không được bỏ trống.")]
	public long CreatedDate { get; set; }
	//[Required(ErrorMessage = "Không được bỏ trống.")]
	public long LastModifiedDate { get; set; }
	public Guid Id { get; set; }
	[Required(ErrorMessage = "Không được bỏ trống.")]
	[EmailAddress(ErrorMessage = "Email FE phải là định dạng email hợp lệ.")]
	[RegularExpression(@"^[^@\s]+@fe\.edu\.vn$", ErrorMessage = "Email FE phải kết thúc bằng @fe.edu.vn và không chứa khoảng trắng hoặc ký tự tiếng Việt.")]
	public string? AccountFe { get; set; }
	[Required(ErrorMessage = "Không được bỏ trống.")]
	[EmailAddress(ErrorMessage = "Email FPT phải là định dạng email hợp lệ.")]
	[RegularExpression(@"^[^@\s]+@fpt\.edu\.vn$", ErrorMessage = "Email FPT phải kết thúc bằng @fpt.edu.vn và không chứa khoảng trắng hoặc ký tự tiếng Việt.")]
	public string? AccountFpt { get; set; }
	[Required(ErrorMessage = "Không được bỏ trống.")]
	[MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
	public string? Name { get; set; }
	[Required(ErrorMessage = "Không được bỏ trống.")]
	[MaxLength(15, ErrorMessage = "Mã nhân viên không được vượt quá 15 ký tự.")]
	public string? StaffCode { get; set; }
    //Chuyển kiểu dữ liệu long sang date (Lỡ chuyển thực ra không cần ạ:)))
    public Staff()
    {
        // Mặc định là Đang hoạt động
        Status = 1;
    }
    public void DoiTrangThai()
    {
        Status = (byte)(Status == 1 ? 0 : 1);
    }
    public string StatusString
    {
        get
        {
            return Status == 1 ? "Đang hoạt động" : "Không hoạt động";
        }
    }
    //public string IdString
    //{
    //    get => Id.ToString();
    //    set
    //    {
    //        if (Guid.TryParse(value, out var result))
    //        {
    //            Id = result;
    //        }
    //        else
    //        {
    //            Id = Guid.Empty; // Or handle invalid GUID case as needed
    //        }
    //    }
    //}
        [NotMapped]
	public DateTime CreatedDateTime
	{
		get => DateTimeOffset.FromUnixTimeMilliseconds(CreatedDate).DateTime;
		set => CreatedDate = new DateTimeOffset(value).ToUnixTimeMilliseconds();
	}

	[NotMapped]
	public DateTime LastModifiedDateTime
	{
		get => DateTimeOffset.FromUnixTimeMilliseconds(LastModifiedDate).DateTime;
		set => LastModifiedDate = new DateTimeOffset(value).ToUnixTimeMilliseconds();
	}
	public virtual ICollection<DepartmentFacility>? DepartmentFacilities { get; set; } = new List<DepartmentFacility>();

    public virtual ICollection<StaffMajorFacility>? StaffMajorFacilities { get; set; } = new List<StaffMajorFacility>();
}

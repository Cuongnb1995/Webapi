namespace WebApplication1.Models
{
    public class ViewEmployee
    {
        public int? EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public string GenderName
        {
            get
            {
                if (Gender == 1)
                    return "Nam";
                else
                    return "Nữ";
            }
        }

        public DateTime? DateOfBirth { get; set; }
        public string CitizenIdentityCode { get; set; }
        public string CitizebIdentityPlace { get; set; }
        public DateTime? CitizebIdentityDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkState { get; set; }
        public string WorkStateName
        {
            get
            {
                switch (WorkState)
                {
                    case 0:
                        return "Đã nghỉ việc";
                    case 1:
                        return "Đang làm việc";
                    case 2:
                        return "Đang thử việc";
                    default:
                        return string.Empty;
                }
            }
        }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public string SelfTaxCode { get; set; }
        public double? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
    }
}

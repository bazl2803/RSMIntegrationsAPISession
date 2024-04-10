namespace Application.DTOs.Departament
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
    }
}

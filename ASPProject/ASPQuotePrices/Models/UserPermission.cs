using System;

namespace WinFormApp.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Section { get; set; }
        public bool HasRead { get; set; }
        public bool HasWrite { get; set; }
        public string AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}

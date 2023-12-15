using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIBDD_Project.Infrastructure.ViewModels
{
    public partial class UserViewModel
    {
        public long ID { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long RoleID { get; set; }
        public RoleViewModel Role {  get; set; }
    }
}

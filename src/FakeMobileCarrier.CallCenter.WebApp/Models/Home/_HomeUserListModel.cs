using System.Collections.Generic;

namespace FakeMobileCarrier.CallCenter.WebApp.Models.Home
{
    public class _HomeUserListModel
    {
        public List<_HomeUserModel> Users { get; set; }

        public _HomeUserListModel()
        {
            Users = new List<_HomeUserModel>();
        }
    }
}
namespace FakeMobileCarrier.CallCenter.WebApp.Models.Home
{
    public class HomeModel
    {
        public _HomeSearchUserModel SearchUserModel { get; set; }

        public _HomeUserListModel UserListModel { get; set; }

        public HomeModel()
        {
            SearchUserModel = new _HomeSearchUserModel();
            UserListModel = new _HomeUserListModel();
        }
    }
}
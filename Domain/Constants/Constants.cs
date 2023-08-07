
namespace Domain.Constants
{
    public class Constants
    {
        public enum ApplicationStatuses
        {
            WaitingForApproval = 0,
            Approved = 1,
            NotApproved = 2
        }

        public enum ApplicationTypes
        {
            Ownership = 0,
            Acceptance = 1
        }

        public enum ActionTypes
        {
            Create = 0,
            Update = 2,
            List = 3,
            Error = 4,
            Delete = 5
        }
        public enum AlertTypes
        {
            info = 0,
            success = 1,
            danger = 2
        }

        public enum SweetAlertTypes
        {
            PredictionSave = 0,
            Error = 1,
            UserEmailPassWordInCorrect = 2
        }

        public enum StatusCodes
        {
            Aktif = 1,
            Pasif = 0
        }

        public enum Colors
        {
            Beyaz = 1,
            Siyah = 2,
            Kahverengi = 3,
            Sarı = 4,
            Yeşil = 5,
            Gri = 6,

        }
    }
}


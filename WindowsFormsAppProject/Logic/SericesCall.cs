using BusinessServices.Dto;
using BusinessServices.Services.Repoistory;
using System.Reflection;
using BusinessServices.Services.Interfaces;

namespace WindowsFormsAppProject.Logic
{
    public class SericesCall
    {

        public async Task<VerifyActionReponse> GetCategoryAsync(RequestDto requestDto)
        {
            CategoryService categoryService = new CategoryService();
            var respone = await categoryService.GetCategoriesData(requestDto);
            return respone;
        }

        public async Task<VerifyActionReponse> GetRetailerAsync(RequestDto requestDto)
        {
            RetailerService retailerService = new RetailerService();
            var response = await retailerService.GetRetailsData(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetRegisterAsync(RequestDto requestDto)
        {
            RegisterService registerService = new RegisterService();
            var response = await registerService.RgisterData(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetLoginAsync(RequestDto requestDto)
        {
            LoginService loginService = new LoginService();
            var response = await loginService.LoginData(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetNotificationAsync(RequestDto requestDto)
        {
            NotificationService notificationService = new NotificationService();
            var response = await notificationService.GetDataNottify(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCardAsync(RequestDto requestDto)
        {            
            CardService cardService = new CardService();
            var response = await cardService.GetDataCard(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetBankAsync(RequestDto requestDto)
        {
            BankProductservice bankProductservice = new BankProductservice();
            var response = await bankProductservice.GetDataBank(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCustDealAsync(RequestDto requestDto)
        {
            CustomerDealService customerDealService = new CustomerDealService();
            var response = await customerDealService.GetDataCustomer(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCustDetailsAsync(RequestDto requestDto)
        {
            CustomerDetailsService customerDetailsService = new CustomerDetailsService();
            var response = await customerDetailsService.GetDataDeal(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCustSearchAsync(RequestDto requestDto)
        {
            CustomerSearchService customerSearchService = new CustomerSearchService();
            var response = await customerSearchService.SearchCustomerDataDeal(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCustIdNumAsync(RequestDto requestDto)
        {
            CustomerIdNumberService customerIdNumberService = new CustomerIdNumberService();
            var response = await customerIdNumberService.CustomerIdNumberDataDeal(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetCustAdditionalAsync(RequestDto requestDto)
        {
            CustomerAdditinalService customerAdditinalService = new CustomerAdditinalService();
            var response = await customerAdditinalService.CustomerFieldDataDeal(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetForgetPassAsync(RequestDto requestDto)
        {
            ForgetPasswordService forgetPasswordService = new ForgetPasswordService();
            var response = await forgetPasswordService.ResponseDataChanged(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetPinAsync(RequestDto requestDto)
        {
            CheckPinService checkPinService = new CheckPinService();
            var response = await checkPinService.CheckBinMethod(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetMobikeExistAsync(RequestDto requestDto)
        {
            MobileExisService mobileExisService = new MobileExisService();
            var response = await mobileExisService.mobileExisResponse(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetChangePassAsync(RequestDto requestDto)
        {
            ChangedPasswordService changedPasswordService = new ChangedPasswordService();
            var response = await changedPasswordService.changedResponseMehod(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetRefreshTokenAsync(RequestDto requestDto)
        {
            RefreshService refreshService = new RefreshService();
            var response = await refreshService.GetRefreshMethod(requestDto);
            return response;
        }

        public async Task<VerifyActionReponse> GetLogoutAsync(RequestDto requestDto)
        {
            LogoutService logoutService = new LogoutService();
            var response = await logoutService.ExecLogoutMethod(requestDto);
            return response;
        }

    }
}

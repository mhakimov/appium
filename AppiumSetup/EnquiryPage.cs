using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Vanquis.Originations.APM.Core.Webtests.Helper;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumSetup
{
    public class EnquiryPage
    {

        public IWebDriver driver;
        public EnquiryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "radioTitle0")]
        [CacheLookup]
        public IWebElement TitleMr { get; set; }

        [FindsBy(How = How.Id, Using = "radioTitle1")]
        [CacheLookup]
        public IWebElement TitleMrs { get; set; }

        [FindsBy(How = How.Id, Using = "radioTitle2")]
        [CacheLookup]
        public IWebElement TitleMiss { get; set; }

        [FindsBy(How = How.Id, Using = "radioTitle3")]
        [CacheLookup]
        public IWebElement TitleMs { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        [CacheLookup]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        [CacheLookup]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        [CacheLookup]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "DateOfBirthDay")]
        [CacheLookup]
        public IWebElement DOBDay { get; set; }

        [FindsBy(How = How.Id, Using = "DateOfBirthMonth")]
        [CacheLookup]
        public IWebElement DOBMonth { get; set; }

        [FindsBy(How = How.Id, Using = "DateOfBirthYear")]
        [CacheLookup]
        public IWebElement DOBYear { get; set; }



        [FindsBy(How = How.Id, Using = "Title-error")]
        [CacheLookup]
        public IWebElement TitleErrorTxt { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName-error")]
        [CacheLookup]
        public IWebElement FirstnameErrorTxt { get; set; }

        [FindsBy(How = How.Id, Using = "LastName-error")]
        [CacheLookup]
        public IWebElement LastNameErrorTxt { get; set; }

        [FindsBy(How = How.Id, Using = "Email-error")]
        [CacheLookup]
        public IWebElement EmailErrorTxt { get; set; }

        [FindsBy(How = How.Id, Using = "DateError")]
        [CacheLookup]
        public IWebElement DOBErrorTxt { get; set; }


        public void ClickTitle(string Title)
        {
            switch (Title.ToUpper())
            {
                case "MR":
                    TitleMr.SendKeys(Keys.Space);
                    break;
                case "MRS":
                    TitleMrs.SendKeys(Keys.Space);
                    break;
                case "MISS":
                    TitleMiss.SendKeys(Keys.Space);
                    break;
                case "MS":
                    TitleMs.SendKeys(Keys.Space);
                    break;
            }
        }

        public void ClickFirstNameField() => FirstName.Click();
        public void ClickLastNameField() => LastName.Click();
        public void ClickEmailField() => Email.Click();
        public void ClickDOBDay() => DOBDay.Click();
        public void ClickDOBMonth() => DOBMonth.Click();
        public void ClickDOBYear() => DOBYear.Click();


        public void ClickAndKeyInDOB(string dob)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            DateTime dateValue = DateTime.Parse(dob);
            DOB(dateValue.Day.ToString(), dateValue.Month.ToString(), dateValue.Year.ToString());
        }

        public void DOB(string dd, string mm, string yyyy)
        {
            //DOBDayEnterText(dd);
            //DOBMonthEnterText(mm);
            //DOBYearEnterText(yyyy);
        }

        public static void ClickAndKeyInText(IWebElement element, string keyInText)
        {
            element.Click();
            element.Clear();
            element.SendKeys(keyInText);
        }

        [FindsBy(How = How.Id, Using = "Postcode")]
        [CacheLookup]
        public IWebElement Postcode { get; set; }

        [FindsBy(How = How.Id, Using = "btnFindAddress")]
        [CacheLookup]
        public IWebElement FindAddressBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='addressList']/div[@class='btnRadioAddress']/label")]
        [CacheLookup]
        public IList<IWebElement> AddressLookupDrpDwn { get; set; }

        [FindsBy(How = How.Id, Using = "btnUseSelectedAddress")]
        [CacheLookup]
        public IWebElement UseSelectedAddressBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='flatNo']")]
        [CacheLookup]
        public IWebElement AddressConfirmationFlatNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='houseNo']")]
        [CacheLookup]
        public IWebElement AddressConfirmationHouseNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='houseName']")]
        [CacheLookup]
        public IWebElement AddressConfirmationHouseName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='street']")]
        [CacheLookup]
        public IWebElement AddressConfirmationStreet { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='city']")]
        [CacheLookup]
        public IWebElement AddressConfirmationCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='county']")]
        [CacheLookup]
        public IWebElement AddressConfirmationCounty { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetails']/p/span[@class='postcode']")]
        [CacheLookup]
        public IWebElement AddressConfirmationPostcode { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddressNotListed")]
        [CacheLookup]
        public IWebElement AddressNotListedBtn { get; set; }

        [FindsBy(How = How.Id, Using = "HouseName")]
        [CacheLookup]
        public IWebElement HouseName { get; set; }

        [FindsBy(How = How.Id, Using = "HouseNumber")]
        [CacheLookup]
        public IWebElement HouseNumber { get; set; }

        [FindsBy(How = How.Id, Using = "FlatNumber")]
        [CacheLookup]
        public IWebElement FlatNumber { get; set; }

        [FindsBy(How = How.Id, Using = "StreetAddress")]
        [CacheLookup]
        public IWebElement Street { get; set; }

        [FindsBy(How = How.Id, Using = "Town")]
        [CacheLookup]
        public IWebElement Town { get; set; }

        [FindsBy(How = How.Id, Using = "County")]
        [CacheLookup]
        public IWebElement County { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus0")]
        [CacheLookup]
        public IWebElement ResStatusCouncilTennant { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus1")]
        [CacheLookup]
        public IWebElement ResStatusJointOwnership { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus2")]
        [CacheLookup]
        public IWebElement ResStatusLivingWithParents { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus3")]
        [CacheLookup]
        public IWebElement ResStatusOwner { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus4")]
        [CacheLookup]
        public IWebElement ResStatusTenantFurnished { get; set; }

        [FindsBy(How = How.Id, Using = "radioResidentialStatus5")]
        [CacheLookup]
        public IWebElement ResStatusTennantUnFurnished { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='radioCurrentAddressYears0']")]
        [CacheLookup]
        public IWebElement LiveAddLess1Year { get; set; }

        [FindsBy(How = How.Id, Using = "radioCurrentAddressYears1")]
        [CacheLookup]
        public IWebElement LiveAdd1Year { get; set; }

        [FindsBy(How = How.Id, Using = "radioCurrentAddressYears2")]
        [CacheLookup]
        public IWebElement LiveAdd2Year { get; set; }

        [FindsBy(How = How.Id, Using = "radioCurrentAddressYears3")]
        [CacheLookup]
        public IWebElement LiveAdd3Year { get; set; }

        [FindsBy(How = How.Id, Using = "radioCurrentAddressYears4")]
        [CacheLookup]
        public IWebElement LiveAdd4Year { get; set; }

        [FindsBy(How = How.Id, Using = "radioCurrentAddressYears5")]
        [CacheLookup]
        public IWebElement LiveAddGreater5Years { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousPostcode")]
        [CacheLookup]
        public IWebElement PreviousPostcode { get; set; }

        [FindsBy(How = How.Id, Using = "btnFindPreviousAddress")]
        [CacheLookup]
        public IWebElement PreviousFindAddressBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='addressListPrevious']/div[@class='btnRadioAddress']/label")]
        [CacheLookup]
        public IList<IWebElement> PreviousAddressLookupDrpDwn { get; set; }



        [FindsBy(How = How.Id, Using = "btnUseSelectedAddressPrevious")]
        [CacheLookup]
        public IWebElement UseSelectedPreviousAddressBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='flatNo']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationFlatNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='houseNo']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationHouseNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='houseName']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationHouseName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='street']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationStreet { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='city']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='county']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationCounty { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='addressDetailsPrevious']/p/span[@class='postcode']")]
        [CacheLookup]
        public IWebElement PreviousAddressConfirmationPostcode { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddressNotListedPrevious")]
        [CacheLookup]
        public IWebElement PreviousAddressNotListedBtn { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousHouseName")]
        [CacheLookup]
        public IWebElement PreviousHouseName { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousHouseNumber")]
        [CacheLookup]
        public IWebElement PreviousHouseNumber { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousFlatNumber")]
        [CacheLookup]
        public IWebElement PreviousFlatNumber { get; set; }


        [FindsBy(How = How.Id, Using = "PreviousStreetAddress")]
        [CacheLookup]
        public IWebElement PreviousStreet { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousTown")]
        [CacheLookup]
        public IWebElement PreviousTown { get; set; }

        [FindsBy(How = How.Id, Using = "PreviousCounty")]
        [CacheLookup]
        public IWebElement PreviousCounty { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/input[@id='HomePhone']")]
        [CacheLookup]
        public IWebElement HomePhone { get; set; }

        [FindsBy(How = How.Id, Using = "WorkPhone")]
        [CacheLookup]
        public IWebElement WorkPhone { get; set; }

        [FindsBy(How = How.Id, Using = "MobilePhone")]
        [CacheLookup]
        public IWebElement MobilePhone { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus0")]
        [CacheLookup]
        public IWebElement FullTime { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus1")]
        [CacheLookup]
        public IWebElement Homemaker { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='part-time-working-hours']/div/div[1]")]
        [CacheLookup]
        public IWebElement HowManyHoursAWeekDoYouWork { get; set; }

        [FindsBy(How = How.Id, Using = "WorkingHours")]
        [CacheLookup]
        public IWebElement WorkingHours { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus1")]
        [CacheLookup]
        public IWebElement NotEmployed { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus2")]
        [CacheLookup]
        public IWebElement PartTime { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus3")]
        [CacheLookup]
        public IWebElement Retired { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus4")]
        [CacheLookup]
        public IWebElement SelfEmployed { get; set; }

        [FindsBy(How = How.Id, Using = "radioEmploymentStatus5")]
        [CacheLookup]
        public IWebElement Student { get; set; }

        [FindsBy(How = How.Id, Using = "radioMonthlyOrAnnualSelect0")]
        [CacheLookup]
        public IWebElement HouseHoldIncomeAnnual { get; set; }

        [FindsBy(How = How.Id, Using = "radioMonthlyOrAnnualSelect1")]
        [CacheLookup]
        public IWebElement HouseHoldIncomeMonthly { get; set; }

        [FindsBy(How = How.Id, Using = "AnnualHouseholdIncome")]
        [CacheLookup]
        public IWebElement AnnualHouseHoldIncomeMonetary { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyHouseholdIncome")]
        [CacheLookup]
        public IWebElement MonthlyHouseHoldIncomeMonetary { get; set; }

        [FindsBy(How = How.Id, Using = "radioFinancialCircumstances0")]
        [CacheLookup]
        public IWebElement FinancialCirumtancesYes { get; set; }

        [FindsBy(How = How.Id, Using = "radioFinancialCircumstances1")]
        [CacheLookup]
        public IWebElement FinancialCirumtancesNo { get; set; }

        [FindsBy(How = How.Id, Using = "radioCashAdvance0")]
        [CacheLookup]
        public IWebElement CashAdvanceYes { get; set; }

        [FindsBy(How = How.Id, Using = "radioCashAdvance1")]
        [CacheLookup]
        public IWebElement CashAdvanceNo { get; set; }

        [FindsBy(How = How.Id, Using = "CashAdvanceAmount")]
        [CacheLookup]
        public IWebElement CashAdvanceAmount { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='part-time-working-hours']/div/div[2]/span[2]/span[2]")]
        [CacheLookup]
        public IWebElement WarningTextMoreThan35Hours { get; set; }

        [FindsBy(How = How.Id, Using = "AnnualPersonalIncome")]
        [CacheLookup]
        public IWebElement AnnualPersonalIncomeValue { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyPersonalIncome")]
        [CacheLookup]
        public IWebElement MonthlyPersonalIncomeValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='formSection-employment']/div[3]/div/div/div[2]/span[1]/label")]
        [CacheLookup]
        public IWebElement AnnualPersonal { get; set; }

        //*[@id="formSection-employment"]/div[3]/div/div/div[2]/span[2]/label
        [FindsBy(How = How.XPath, Using = "//*[@id='formSection-employment']/div[3]/div/div/div[2]/span[2]/label")]
        [CacheLookup]
        public IWebElement MonthlyPersonal { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='isAnnualPersonalIncome']/span[4]")]
        [CacheLookup]
        public IWebElement ThisMeansYourMonthlyPersonalIncomeTx { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='isMonthlyPersonalIncome']/span[4]")]
        [CacheLookup]
        public IWebElement ThisMeansYourAnnualPersonalIncomeTx { get; set; }

        [FindsBy(How = How.Id, Using = "AnnualPersonalIncome-error")]
        [CacheLookup]
        public IWebElement AnnualPersonalIncomeWarningTx { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyPersonalIncome-error")]
        [CacheLookup]
        public IWebElement MonthlyPersonalIncomeWarningTx { get; set; }

        [FindsBy(How = How.Id, Using = "sbtApplication")]
        [CacheLookup]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyRentMortgage-error")]
        [CacheLookup]
        public IWebElement PleaseEnterYourHouseholdMortgageTx { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyRentMortgage")]
        [CacheLookup]
        public IWebElement MonthlyRentMortgage { get; set; }

        [FindsBy(How = How.Id, Using = "FBAnnual")]
        [CacheLookup]
        public IWebElement YourIncomeAnnual { get; set; }

        [FindsBy(How = How.Id, Using = "FBMonthly")]
        [CacheLookup]
        public IWebElement YourIncomeMonthly { get; set; }

        [FindsBy(How = How.Id, Using = "FBAnnualTotal")]
        [CacheLookup]
        public IWebElement TotalHouseholdIncomeAnnual { get; set; }

        [FindsBy(How = How.Id, Using = "FBMonthlyTotal")]
        [CacheLookup]
        public IWebElement TotalHouseholdIncomeMonthly { get; set; }

        [FindsBy(How = How.Id, Using = "NumberOfDependents-error")]
        [CacheLookup]
        public IWebElement DependentsErrorTx { get; set; }


        [FindsBy(How = How.Id, Using = "EmploymentStatus-error")]
        [CacheLookup]
        public IWebElement EmploymentStatusErrortxt { get; set; }

        [FindsBy(How = How.Id, Using = "AnnualHouseholdIncome-error")]
        [CacheLookup]
        public IWebElement AnnualHouseholdIncomeErrortxt { get; set; }

        [FindsBy(How = How.ClassName, Using = "incomeicon-monthly")]
        [CacheLookup]
        public IWebElement AnnualHouseholdIncomeErrorimgicon { get; set; }

        [FindsBy(How = How.Id, Using = "MonthlyHouseholdIncome-error")]
        [CacheLookup]
        public IWebElement MonthlyHouseholdIncomeErrortxt { get; set; }

        [FindsBy(How = How.Id, Using = "FinancialCircumstances-error")]
        [CacheLookup]
        public IWebElement FinancialCircumstanceErrortxt { get; set; }

        [FindsBy(How = How.Id, Using = "CashAdvance-error")]
        [CacheLookup]
        public IWebElement CashAdvanceErrortxt { get; set; }

        [FindsBy(How = How.Id, Using = "CashAdvanceAmount-error")]
        [CacheLookup]
        public IWebElement CashAdvanceAmountErrortxt { get; set; }
        public void EnterPostcodeAndLookup(string postcode)
        {

            Random rnd = new Random();
            Postcode.SendKeys(postcode);
            FindAddressBtn.Click();

            var AddressDropDownCount = AddressLookupDrpDwn.Count();
            Console.WriteLine("Using @FindBys, we found " + AddressLookupDrpDwn.Count() + " element(s)");

            if (AddressDropDownCount == 1)
            {
                var ChooseAddress = AddressLookupDrpDwn.ElementAt(0);
                AddressLookupDrpDwn.ElementAt(0).Click();
            }
            else
            {
                if (AddressDropDownCount != 0)
                {
                    var RandAddress = rnd.Next(1, AddressDropDownCount);
                    var ChooseAddress = AddressLookupDrpDwn.ElementAt(RandAddress);
                    AddressLookupDrpDwn.ElementAt(RandAddress).Click();
                }

                else
                {
                    Assert.False(AddressDropDownCount != 0, "There wasnt any addresses in the postcode");
                }
            }
        }

        public IWebElement GetResidentialStatus(string status)
        {
            switch (status)
            {
                case "Council":
                    return ResStatusCouncilTennant;
                case "Joint Owner":
                    return ResStatusJointOwnership;
                case "Parents":
                    return ResStatusLivingWithParents;
                case "Tenant Furnished":
                    return ResStatusTenantFurnished;
                case "Owner":
                    return ResStatusOwner;
                case "Tenant Unfurnished":
                    return ResStatusTennantUnFurnished;
                case "Other Tenant":
                    return ResStatusTenantFurnished;
                default:
                    Assert.Inconclusive("Incorrect Residential Status the Test Cannot Continue");
                    return null;
            }
        }

        public IWebElement GetCurrentAddressYears(string stringyears)
        {
            decimal years = System.Convert.ToDecimal(stringyears);
            if (years < 1.0m) return LiveAddLess1Year;
            if (years >= 1.0m && years < 2.0m) return LiveAdd1Year;
            if (years >= 2.0m && years < 3.0m) return LiveAdd2Year;
            if (years >= 3.0m && years < 4.0m) return LiveAdd3Year;
            if (years >= 4.0m && years < 5.0m) return LiveAdd4Year;
            if (years >= 5.0m) return LiveAddGreater5Years;
            else
                Assert.Inconclusive("Incorrect Current Address Years the Test Cannot Continue");
            return null;
        }

        public IWebElement GetEmploymentStatus(string status)
        {
            switch (status)
            {
                case "Full Time":
                    return FullTime;
                case "Homemaker":
                    return Homemaker;
                case "Unemployed":
                    return NotEmployed;
                case "Part Time":
                    return PartTime;
                case "Retired":
                    return Retired;
                case "Self Employed":
                    return SelfEmployed;
                case "Student":
                    return Student;
                default:
                    Assert.Inconclusive("Incorrect Employment Status the Test Cannot Continue");
                    return null;
            }
        }

        public IWebElement GetFinancialCircumstances(string financialstatus)
        {
            switch (financialstatus)
            {
                case "True":
                    return FinancialCirumtancesYes;
                case "False":
                    return FinancialCirumtancesNo;
                default:
                    Assert.Inconclusive("Incorrect Financial Circumstances the Test Cannot Continue");
                    return null;
            }
        }

        public void ClickResidentialStatus(string status)
        {
            GetResidentialStatus(status).SendKeys(Keys.Space);
        }

        public void EnterPreviousPostcodeAndLookup(string previouspostcode)
        {
            Random rnd = new Random();
            PreviousPostCodeEnterText(previouspostcode);
            Thread.Sleep(1000);
            ClickFindPreviousAddress();

            var PreviousAddressDropDownCount = PreviousAddressLookupDrpDwn.Count();
            Console.WriteLine("Using @FindBys, we found " + PreviousAddressLookupDrpDwn.Count() + " element(s)");

            if (PreviousAddressDropDownCount == 1)
            {
                var ChoosePreviousAddress = PreviousAddressLookupDrpDwn.ElementAt(0);

                ChoosePreviousAddress.Click();
            }
            else
            {
                if (PreviousAddressDropDownCount != 0)
                {
                    var PreviousRandAddress = rnd.Next(1, PreviousAddressDropDownCount);
                    var ChoosePreviousAddress = PreviousAddressLookupDrpDwn.ElementAt(PreviousRandAddress);

                    ChoosePreviousAddress.Click();
                }

                else

                {
                    Assert.False(PreviousAddressDropDownCount != 0, "There wasnt any addresses in the postcode");
                }
            }
        }

        public void PreviousPostCodeEnterText(string enterText)
        {
            var id = "PreviousPostcode";
            driver.WaitUntilAllExists(By.Id(id));
            PreviousPostcode.ClickAndKeyInText(enterText);
        }

        public void ClickFindPreviousAddress()
        {
            PreviousFindAddressBtn.Click();
            //  PreviousFindAddressBtn.SendKeys(Keys.Space);
        }
    }
}

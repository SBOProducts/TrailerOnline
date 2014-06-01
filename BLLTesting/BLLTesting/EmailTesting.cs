using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailerOnline.BLL;
using TrailerOnline.DAL.DAL.dbo;
using TrailerOnline.DAL.DO.dbo;

namespace BLLTesting
{
    public class EmailTesting
    {
        public EmailTesting()
        {

        }

        public void Run() 
        {
            DropTemplate();
            CreateTemplate();
            GetConfirmAccountEmail();
        }

        void DropTemplate()
        {
            Template.Truncate();
        }

        private void CreateTemplate()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Name = "ConfirmYourAccount",
                Type = "Email",
                Content = @"      
<p>Welcome to Trailer Cloud,</p>
<p>
Thank you for creating a Trailer Cloud account. In order to gain full access to our system you must first
confirm your account by clicking the link provided below. Once your account has been confirmed you will
be able to create a free Trailer Cloud website.
</p>

<h3>Confirm Account</h3>
<p>
<a href='http://trailercloud.com/Service/Account/VerifyAccount?id=@Model.ConfirmationToken'>http://trailercloud.com/Service/Account/VerifyAccount?id=@Model.ConfirmationToken</a>
</p>

<p>
Thank you for joining Trailer Cloud. We look forward to serving your business.
</p>

<hr />
<p style='font-size: 9px; color: #999; line-height: 12px; margin-top: 0px; text-align: center; font-family: Arial, Helvetica, sans-serif;'>
Trailer Cloud is a subsidiary of Small Business Online, LLC.
This message was produced and distributed by Small Business Online, LLC, <a href='http://sboproducts.com'>SBOProducts.com</a>
</p>"
            });

            Console.WriteLine("Tempalte created");
        }

        private void GetConfirmAccountEmail()
        {
            string html = EmailBLL.AccountMessages.GetConfirmAccount("23982947398729472947239487");
            Console.WriteLine(html);
        }
    }
}

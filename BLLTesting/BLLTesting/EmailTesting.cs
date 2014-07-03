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
            CreateWelcomeTemplate();
            CreateYourAccountHasBeenConfirmedTemplate();
            NewAccountConfirmed();
            ResetYourPassword();
            WebsiteCreated();
            HomePage();
            AboutPage();
            ContactPage();
            FooterCol1();
            FooterCol2();
            FooterCol3();
        }

        void DropTemplate()
        {
            Template.Truncate();
        }

        #region Registration Process Emails

        private void CreateWelcomeTemplate()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Name = "ConfirmYourAccount",
                Type = "Email",
                Subject = "Welcome to Trailer Cloud",
                Content = @"      
<p>Welcome to Trailer Cloud,</p>
<p>
Thank you for creating a Trailer Cloud account. In order to gain full access to our system you must first
confirm your account by clicking the link provided below. Once your account has been confirmed you will
be able to create a free Trailer Cloud website.
</p>

<h3>Confirm Account</h3>
<p>
<a href='http://trailercloud.com/Service/Account/VerifyAccount?id=#ConfirmationToken#'>http://trailercloud.com/Service/Account/VerifyAccount?id=#ConfirmationToken#</a>
</p>

<p>
Thank you for joining Trailer Cloud. We look forward to serving your business.
</p>

<hr />
<p style='font-size: 9px; color: #999; line-height: 12px; margin-top: 0px; text-align: center; font-family: Arial, Helvetica, sans-serif;'>
Trailer Cloud is a subsidiary of Small Business Online, LLC.
This message was produced and distributed by Small Business Online, LLC, <a href='http://sboproducts.com'>SBOProducts.com</a>
</p>
"
            });

            Console.WriteLine("welcome to trailer cloud tempalte created");
        }

        private void CreateYourAccountHasBeenConfirmedTemplate()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Name = "YourAccountHasBeenConfirmed",
                Type = "Email",
                Subject = "Trailer Cloud Account Confirmed",
                Content = @"      
<p>Thank you for confirming your account.</p>
<p>You may now log into <a href='http://www.trailercloud.com'>Trailer Cloud</a> to create your trailer sales website.</p>

<p>Thank you,</p>
<p>Trailer Cloud</p>

<hr />
<p style='font-size: 9px; color: #999; line-height: 12px; margin-top: 0px; text-align: center; font-family: Arial, Helvetica, sans-serif;'>
Trailer Cloud is a subsidiary of Small Business Online, LLC.
This message was produced and distributed by Small Business Online, LLC, <a href='http://sboproducts.com'>SBOProducts.com</a>
</p>
"
            });

            Console.WriteLine("Trailer Cloud Account Confirmed Tempalte created");
        }

        private void NewAccountConfirmed()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Name = "NewAccountConfirmed",
                Type = "Email",
                Subject = "New Account Confirmed",
                Content = @"      
<h3>New Account</h3>
<p>A new account has been confirmed!</p>
<h4>#ConfirmedEmailAddress#</h4>
"
            });

            Console.WriteLine("New Account Confirmed Tempalte created");
        }

        private void ResetYourPassword()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Type = "Email",
                Name = "PasswordReset",
                Subject = "Reset your Trailer Cloud password",
                Content = @"      
<h3>Trailer Cloud Password Reset</h3>
<p>
Use the link below to reset your password. If you did not request to have your password reset, please ignore this message. The link below is valid for 24 hours. 
</p>

<p>
<a href='http://trailercloud.com/service/account/updatepassword?id=#token#'>http://trailercloud.com/service/account/updatepassword?id=#token#</a>
</p>

<p>Sincerely,</p>
<p>Trailer Cloud</p>

<hr />
<p style='font-size: 9px; color: #999; line-height: 12px; margin-top: 0px; text-align: center; font-family: Arial, Helvetica, sans-serif;'>
Trailer Cloud is a subsidiary of Small Business Online, LLC.
This message was produced and distributed by Small Business Online, LLC, <a href='http://sboproducts.com'>SBOProducts.com</a>
</p>
"
            });

            Console.WriteLine("Reset your Trailer Cloud password Tempalte created");
        }

        private void WebsiteCreated()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Account",
                Name = "WebsiteCreated",
                Type = "Email",
                Subject = "Your Trailer Cloud Website Is Ready",
                Content = @"      
<h3>Website Created</h3>
<p>Congratulations, your Trailer Cloud website has been created and is ready for you to use.</p>
<h4><a href='#WebsiteUrl#'>#WebsiteUrl#</a></h4>
"
            });

            Console.WriteLine("Your Trailer Cloud Website Is Ready Tempalte created");
        }

        #endregion


        #region Html Content 

        void HomePage()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "HomePage",
                Type = "Html",
                Subject = "Default Content",
                Content = @"      
<h1>#BusinessName#</h1>

<p>Welcome, this is your website! This is some sample content to get you started.</p>

<p>Your website pages work just like a word processor. When you&#39;re logged in and click a page you&#39;ll see the toolbar appear, like below. If you&#39;ve ever used Microsoft Word or Open Office this will seem natural. Go ahead, give it a try. You don&#39;t need to worry about saving either, your website does that automatically whenever you click off of the content and the toolbar disappears.</p>

<p><img alt='edit pages just like using a word processor' src='http://trailercloud.com/images/editor.png' style='border-style:solid; border-width:2px; height:73px; width:473px' /></p>

<p>Adding images is a breeze, simply drag them onto your web page from your desktop of folder. That&#39;s it.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>"
            });

            Console.WriteLine("Home page content template created");
        }

        void AboutPage()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "AboutPage",
                Type = "Html",
                Subject = "Default Content",
                Content = @"      
<h1>About #BusinessName#</h1>

<p>
    What? You want me to write about my business? 
</p>
<p>
    Your website is awesome, and your products look great. But customers won't pick up the phone or get in their car until they decide you're legit. And they're coming to this page to make that decision. 
</p>
</h3>Pointers</h3>
<p>
    The biggest thing is to not over complicate it. Nobody likes writing this stuff, but customers need it and will get a bad impression if you don't try. 
    So take a deep breath, and give it a shot. You can change it any time you please. 
</p>
<h3>What most people are looking for</h3>
<ul>
    <li>A brief bio of your company including name, how many people you employ, how long you've been in business, and maybe how you got started</li>
    <li>What services do you offer</li>
    <li>What type of inventory do you cary - new, used, brands, etc.</li>
    <li>Where you're located and how you can be reached (phone, fax, email, social media)</li>
</ul>

<h3>Some helpful links</h3>
<p>
    <a href='http://www.copyblogger.com/how-to-write-an-about-page/'>How to write an about page</a>
</p>
<p>
    <a href='http://bostinno.streetwise.co/2011/05/26/5-must-haves-for-your-companys-about-page/'>5 Must Haves for Your Company's About Page</a>
</p>

<p>&nbsp;</p>
<p>&nbsp;</p>"
            });

            Console.WriteLine("About page content template created");
        }

        void ContactPage()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "ContactPage",
                Type = "Html",
                Subject = "Default Content",
                Content = @"      
<h1>Contact #BusinessName#</h1>

<p>
    Your contact page needs to provide customers means of contacting you. 
</p>

<ul>
    <li>Business Name</li>
    <li>Address</li>
    <li>Phone Numbers</li>
    <li>Fax Numbers</li>
</ul>

<p>&nbsp;</p>
<p>&nbsp;</p>"
            });

            Console.WriteLine("Contact page content template created");
        }


        void FooterCol1()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "FooterCol1",
                Type = "Html",
                Subject = "Column1",
                Content = @"      
<p>
<em>you can edit this too</em>
</p>
<h3>#BusinessName#</h3>
<p>2014 Today Lane, <br/>Yourtown USA</p>
<p>(800) 555-5555</p>
"
            });

            Console.WriteLine("Footer Column 1 template created");
        }

        void FooterCol2()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "FooterCol2",
                Type = "Html",
                Subject = "Column 2",
                Content = @"      
<p>
<em>testimonials?</em>
</p>
<blockquote>
<p>You guys are the best, you always have what I need and your service is incredible</p>
</blockquote>
"
            });

            Console.WriteLine("Footer Column 2 template created");
        }

        void FooterCol3()
        {
            Template.Create(new TemplateDO()
            {
                Category = "Content",
                Name = "FooterCol3",
                Type = "Html",
                Subject = "Column 3",
                Content = @"      
<p>
<small>Our logo only shows on free demo websites, you'll be able to use the space to the right on a purchased website.</small>
</p>
"
            });

            Console.WriteLine("Footer Column 3 template created");
        }

        #endregion
    }
}

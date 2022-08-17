using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using LoginPanel.Models;
using Microsoft.IdentityModel.Tokens;

namespace LoginPanel.Services
{
    public class EmailSender
    {
        public async Task Send(string? receiver)
        {
            if (receiver != null)
            {
                MailAddress from = new("Your Email", "LoginPanel");
                MailAddress to = new(receiver);
                MailMessage mm2 = new(from, to);
                mm2.Subject = "Email Authorization";

                SmtpClient smtp = new();

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from.Address, "Your Password");

                int length = 6;
                var random = new Random();
                var result = string.Join("", Enumerable.Range(0, length).Select(i => i % 2 == 0 ? (char)('A' + random.Next(26)) + "" : random.Next(1, 10) + ""));
                mm2.Body = "<h3>Don't tell, share anyone your code for security purposes</h3> " + '\n' + '\n' +
                            $"Your code - <b>{result}</b>";
                mm2.IsBodyHtml = true;

                await smtp.SendMailAsync(mm2);

                var claims = new List<Claim> { new Claim(ClaimTypes.Authentication, result) };
                var jwt = new JwtSecurityToken(
                       issuer: JWTModel.ISSUER,
                       audience: JWTModel.AUDIENCE,
                       claims: claims,
                       expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                       signingCredentials: new SigningCredentials(JWTModel.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                JWTModel.VALUE = new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            else
            {
                throw new ArgumentException("Recipient not set");
            }
        }
    }
}

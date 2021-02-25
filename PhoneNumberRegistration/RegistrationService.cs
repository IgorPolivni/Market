using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Chat.V2.Service.User;

namespace PhoneNumberRegistration
{
    public class RegistrationService
    {
        public string Registration(string phoneNumber, string[] users)
        {
            if (!ValidPhoneNumber(phoneNumber, users))
            {
                return null;
            }

            string accountSid = "AC194a4f76519c164a36433e3ffc57dedc"; // брать с https://www.twilio.com/console
            string authToken = "262ede6bcbc6b6ce812f47ca8935f6c3"; // брать с https://www.twilio.com/console
            string fromNumber = "+12059736835"; // брать с https://www.twilio.com/console
            string toNumber = phoneNumber; // вводить свой номер (дугие номера только с премиум-аккаунтом)

            TwilioClient.Init(accountSid, authToken);

            var verifyCode = CodeGenerator();

            var message = MessageResource.Create(
                body: $"Ваш код подтверждения: {verifyCode}",
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(toNumber)
            );
            //Console.WriteLine(message.Sid);

            return verifyCode;
        }

        private bool ValidPhoneNumber(string phoneNumber, string[] users)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == phoneNumber)
                {
                    Console.WriteLine("Такой пользователь уже зарегистрирован.");
                    return false;
                }
            }
            return true;
        }

        private string CodeGenerator()
        {
            int lengthOfCode = 4;
            string code = "";
            Random randomNumber = new Random();

            for (int i = 0; i < lengthOfCode; i++)
            {
                code += (char)randomNumber.Next(48, 57);
            }

            return code;
        }
    }
}

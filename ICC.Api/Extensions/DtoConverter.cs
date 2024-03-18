using ICC.Api.Entities;
using ICC.Models.DtOs;
using System.Collections.Generic;
using System.Linq;

namespace ICC.Api.Extensions
{
    public static class DtoConverter
    {
        public static PersonalAccountDto ConvertToDto(this PersonalAccount personalAccount)
        {
            return new PersonalAccountDto
            {
                Id = personalAccount.Id,
                EffectiveDate = personalAccount.EffectiveDate,
                Address = personalAccount.Address,
                Square = personalAccount.Square,
                Residents = personalAccount.Residents
            };
        }

        public static IEnumerable<PersonalAccountDto> ConvertToDto (this IEnumerable<PersonalAccount> personalAccounts)
        {
            return (from persAcc in personalAccounts
                    select new PersonalAccountDto
                    {
                        Id = persAcc.Id,
                        EffectiveDate = persAcc.EffectiveDate,
                        AccountNum = persAcc.AccountNum,
                        Address = persAcc.Address,
                        Square = persAcc.Square,
                        Residents = persAcc.Residents
                    }).ToList();
        }
    }
}

/*
 * @CreateTime: Oct 17, 2018 2:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 17, 2018 2:19 PM
 * @Description: Modify Here, Please 
 */
namespace Smart_Accounting.Application.Ledgers.Models
{
    public abstract class JornalEntryDto
    {
        public float Credit {get; set;}
        public float Debit {get; set;}
        public string AccountId {get; set;}
        public uint Reference {get; set;}


    }
}
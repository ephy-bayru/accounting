/*
 * @CreateTime: Oct 17, 2018 2:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 13, 2018 12:30 PM
 * @Description: Modify Here, Please 
 */
namespace Smart_Accounting.Application.Ledgers.Models
{
    public abstract class JornalEntryDto
    {
        public double Amount {get; set;}
        public string AccountId {get; set;}
        public uint Reference {get; set;}

        public uint? PostingType { get; set; }
        public uint? PostingEntityId { get; set; }


    }
}
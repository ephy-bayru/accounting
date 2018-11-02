/*
 * @CreateTime: Nov 2, 2018 3:08 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:08 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;

namespace Smart_Accounting.Domain.SystemDefault {
    public partial class SystemDefaults {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DataType { get; set; }
        public string Length { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class RecordNotFoundException : Exception//(88)//(89) Bu sınıf hülle sınıfıdır. Exception sınıfından kalıtım almıştır. Bu yüzden Exception sınıfının özelliklerini kullanabilir. Kullanıcıya gönderilecek hatanın yönetimini(HANDLİNG) sağlar.
    {
        public RecordNotFoundException(string message):base(message)
        {
            ////(88)//(89)programcs içinde bulunan find() metodundan oluşturulan hata mesajı, bu sınıfın instance'ı oluşturulup,  parametre olarak buraya gönderilir. daha sonra buradaki message nesnesine yüklenip base sınıfa gönderilir. Böylece catch bloğu içinde exception.message olarak gösterilebilir.
        }
    }
}

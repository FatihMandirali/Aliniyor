## API Mimarisi ve Tasarımı

Proje .Net 5 ile geliştirilip tasarım aşamasında Services ve Models Library'leri oluşturuldu. 

Models Library :

1.  DTO :

   ​	Xml ve excel dosyalarını mapleyebilmek için kullandığım modelleri tutmaktayım

2. Enum :

   ​    Servislerden sıralama ve dosya türünü belirlemek için kontrolü enum ile gerçekleştirdim

3. Request :

   ​	Servislerde kullanılan request modellerini içermektedir

4. Response :

   ​	Servislerde kullanılan response modellerini içermektedir

5. ApiResultModel : 

   ​	Base bir response yapısı oluşturup servis responselerini bu base response üzerinden yönetmek için tasarlandı



Services Library :

1. Interface : 

     Servise gelen requestte dosyayı okuma işlemini servis katmanına yönlendirip dependency injectionlar ile yönetmek için oluşturuldu.

2. Mapper : 

     Excel dosyasını map'leye bilmek için extra olarak kullanılan mapping class'ı

3. Paged : 

    Veri sayısı fazla olduğundan performansı arttırmak için pagination yapısını içeri



## Kullanılan Kütüphaneler

- AutoMapper

  Response modelde kod sayısı azaltmak dto'ları daha kolay doldurabilmek için kullanılan kütüphane

- Swashbuckle.AspNetCore

  Request ve response'ları daha analiz edip test edebilmek için kullanılan kütüphane

- CsvHelper , TinyParser , System.Text.Encoding.CodePages

  Csv ve Excel dosyalarını çözüp modelleyebilmek için kullanılan kütüphane

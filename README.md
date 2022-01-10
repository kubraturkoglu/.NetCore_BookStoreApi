# .NetCoreBookStoreApi
Projede kitapların yazarları için Author controller'vardır. Bu controller ile aşağıdaki işlemlerin gerçekleşmektedir.



* Yazar Ekleme

* Yazar Bilgileri Güncelleme

* Yazar Silme

* Tüm Yazarları Listeleme

* Spesifik Bir Yazarın Bilgilerini Getirme


2.Yazar Bilgileri:


* Ad
* Soyad
* Doğum Tarihi




* Kitabı yayında olan bir yazar silinemez. Öncelikle kitap silinmeli, daha sonra yazar silinebilir.


* Author için model ve dto'ları eklendi.


* Author entity model map'lerini Auto Mapper kullanarak yazıldı.


* Author servisleri için Fluent Validation kullanarak validation sınıflarını yazıldı. 


* Servisler içerisinden anlamlı hata mesajları fırlatılmalı.



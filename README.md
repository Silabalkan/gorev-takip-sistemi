Bu proje, basit bir kullanıcı ve görev yönetim sistemidir.
Backend ASP.NET Core 6.0, Frontend ise HTML, CSS, JavaScript ve Bootstrap kullanılarak geliştirilmiştir.

 Özellikler :
Kullanıcı Kayıt (Register)
Kullanıcı Giriş (Login)
örev Ekleme
Görev Listeleme
Görev Güncelleme
Görev Silme
Görev Tamamlama
Bildirim Sistemi


Notlar
Güvenlik amacıyla kullanıcı şifreleri veritabanına hashlenmiş olarak kaydedilmektedir.
Proje şu anda temel işlevleri kapsıyor, ileri düzey geliştirmeler yapılabilir.
API ve Frontend tamamen birbirinden bağımsız çalışmaktadır (decoupled architecture).

Kurulum ve Çalıştırma :

Projeyi bu repodan klonlayın:

bash
Kopyala
Düzenle
git clone https://github.com/Silabalkan/gorev-takip-sistemi.git
Backend (API) için:

Visual Studio ile aç.
appsettings.json içinde doğru veritabanı bağlantı ayarlarını yap.
Migration oluştur ve veritabanını güncelle (update-database).
API'yi çalıştır (F5 veya Ctrl + F5).
Frontend için:
Frontend klasöründeki index.html dosyasını Live Server ile çalıştır.
Kullanıcı kaydolabilir ve görev yönetimi yapabilirsiniz.



# gorev-takip-sistemi

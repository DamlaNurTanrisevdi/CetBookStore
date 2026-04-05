Bu projede, verdiğiniz CetStudentBook altyapısını kullanarak "Kitaplar" (Book) bölümünü baştan sona kendim inşa ettim. Ödevde belirttiğiniz kurala sadık kalarak, hiçbir aşamada "scaffolding" (otomatik kod oluşturma) araçlarını kullanmadım; her controller metodunu ve her View sayfasını tamamen manuel olarak yazdım.

Neleri Uyguladım?
Ödevde beklediğiniz tüm fonksiyonları şu şekilde tamamladım:

Book Modeli: Id, Name, Author, PublishDate, PageCount ve IsSecondHand alanlarını içeren modelimi oluşturdum.

Doğrulama Kuralları: Model üzerinde [Required], [StringLength] ve [Range] gibi Data Annotation yapılarını kullanarak; isim/yazar zorunluluğu (2-200 karakter) ve sayfa sayısı sınırı (1-10000) gibi tüm kuralları uyguladım.

Listeleme Sayfası (Index): Tüm kitapların listelendiği, her satırda "Edit" ve "Delete" aksiyonlarının bulunduğu tablo yapısını kurdum.

Ekleme (Create): Yeni kitap girişi için gerekli formu ve hem sunucu hem istemci taraflı çalışan doğrulama mekanizmasını hazırladım.

Düzenleme (Edit): Mevcut kayıtları ID üzerinden bulan, formu dolduran ve veritabanında güncelleyen yapıyı oluşturdum.

Silme (Delete): Silme işlemi öncesinde kitap detaylarını gösteren bir onay ekranı hazırladım ve onayın ardından kaydı veritabanından sildim.

Navigasyon: Kullanıcıların her yerden erişebilmesi için _Layout.cshtml dosyasına "Books" linkini manuel olarak ekledim.

Projeyi Yerel Bilgisayarda Çalıştırma Adımları:
Bağımlılıkları yükleyin: dotnet restore
Veritabanı ve Migration İşlemleri:
"Books" tablosunun veritabanında oluşması için şu komutu çalıştırmanız gerekmektedir: dotnet ef database update
Uygulamayı başlatın:dotnet run

<img width="1442" height="755" alt="Ekran Resmi 2026-03-02 00 43 36" src="https://github.com/user-attachments/assets/28c28c1f-850f-4f1e-8900-d286a734ecb3" />
<img width="1442" height="755" alt="Ekran Resmi 2026-03-02 00 57 41" src="https://github.com/user-attachments/assets/6dac10a6-22b0-4aa1-b916-a7c421128ce3" />
<img width="1442" height="755" alt="Ekran Resmi 2026-03-02 00 57 23" src="https://github.com/user-attachments/assets/b62fabd3-c7e4-47e0-a83c-13f6d831014e" />

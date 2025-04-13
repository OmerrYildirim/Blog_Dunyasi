# 📝 Blog Dünyası - .NET Core Blog Uygulaması

Bu proje, Doğuş "Geleceğe Giriş" eğitim programı kapsamında geliştirilmiş bir **.NET Core MVC** tabanlı **Blog Uygulamasıdır**. Eğitim süresince öğrenilen teknolojiler ve yazılım mimarisi ilkeleri kullanılarak, kullanıcıların blog yazıları oluşturabileceği, düzenleyebileceği ve yorum yapabileceği dinamik bir web platformu geliştirilmiştir.

---

## 🚀 Proje Özellikleri

### 1️⃣ Kullanıcı Yönetimi (Authentication & Authorization)

- Kullanıcılar **kayıt olabilir**, **giriş yapabilir** ve **çıkış yapabilir**.
- **Giriş yapmış kullanıcılar**:
  - Blog yazısı ekleyebilir, düzenleyebilir, silebilir.
  - Blog yazılarına yorum yapabilir.
- **Giriş yapmamış kullanıcılar (misafir)**:
  - Sadece blog yazılarını ve yorumları okuyabilir.

### 2️⃣ Blog Yönetimi

Her blog yazısı aşağıdaki alanları içerir:

- Başlık (Title)
- İçerik (Content)
- Yazar (User)
- Yayınlanma Tarihi (CreatedAt)
- Kategori (Category)
- Görsel (Opsiyonel - URL üzerinden)

#### CRUD İşlemleri:
- Blog yazıları **oluşturulabilir**, **görüntülenebilir**, **güncellenebilir**, ve **silinebilir**.

### 3️⃣ Kategori Sistemi

- Bloglar kategoriye göre sınıflandırılır.
- Anasayfada **kategori filtresi** bulunmaktadır.

### 4️⃣ Yorum Sistemi (Opsiyonel)

- Giriş yapmış kullanıcılar bloglara **yorum yapabilir**.
- Yorumlar blog detay sayfasında listelenir.

### 5️⃣ Kullanıcı Profil Sayfası (Opsiyonel)

- Her kullanıcı kendi yazdığı blogları **profil sayfasında görebilir**.

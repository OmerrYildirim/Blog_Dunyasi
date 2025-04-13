using DogusProject.Models.Repositories.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DogusProject.Models.Repositories;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Blog>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Blogs)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Blog>()
            .HasOne(b => b.Category)
            .WithMany(c => c.Blogs)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Blog>()
            .HasMany(b => b.Comments)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.Restrict);


        var users = new List<AppUser>
        {
            new()
            {
                Id = Guid.Parse("1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a"),
                UserName = "ahmet.yilmaz",
                NormalizedUserName = "AHMET.YILMAZ",
                Email = "ahmet@example.com",
                NormalizedEmail = "AHMET@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash =
                    "AQAAAAIAAYagAAAAELbHteO3V4r0ri8qHzGEpzBvqKIKEbLCpYc2F6FFniqNaNUtQBPztGLE+r/3q683VA==", // Ahmet123!
                SecurityStamp = "STATICSTAMP1",
                ConcurrencyStamp = "STATICSTAMP1"
            },
            new()
            {
                Id = Guid.Parse("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b"),
                UserName = "mehmet.kaya",
                NormalizedUserName = "MEHMET.KAYA",
                Email = "mehmet@example.com",
                NormalizedEmail = "MEHMET@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash =
                    "AQAAAAIAAYagAAAAEJwMr9wEqhB+HCfhGmBDX4GLZ72kC6P5K1fBQEcb/+HqWjlYGlBKe47/r5RHs0TLIA==", // Mehmet123!
                SecurityStamp = "STATICSTAMP2",
                ConcurrencyStamp = "STATICSTAMP2"
            },
            new()
            {
                Id = Guid.Parse("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c"),
                UserName = "ayse.demir",
                NormalizedUserName = "AYSE.DEMIR",
                Email = "ayse@example.com",
                NormalizedEmail = "AYSE@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash =
                    "AQAAAAIAAYagAAAAEMPPPOm4CUxBKX9wnIZNJ2AjrYgEEEGYBBBjE1vVRJPXEfD0kF3Bw4e+iX9M8erxpA==", // Ayse123!
                SecurityStamp = "STATICSTAMP3",
                ConcurrencyStamp = "STATICSTAMP3"
            }
        };

        builder.Entity<AppUser>().HasData(users);

        // Seed Categories
        var categories = new List<Category>
        {
            new() { Id = 1, Name = "Teknoloji" },
            new() { Id = 2, Name = "Seyahat" },
            new() { Id = 3, Name = "Yemek" },
            new() { Id = 4, Name = "Spor" },
            new() { Id = 5, Name = "Kültür-Sanat" }
        };

        builder.Entity<Category>().HasData(categories);

        // Seed Blogs
        var blogs = new List<Blog>
        {
            new()
            {
                Id = 1,
                Title = "Yapay Zeka Gelişmeleri",
                Content =
                    "Son yıllarda yapay zeka (YZ) alanında yaşanan gelişmeler, teknoloji dünyasında devrim niteliğinde değişimlere yol açtı. Derin öğrenme, makine öğrenimi ve doğal dil işleme konularındaki ilerlemeler sayesinde, yapay zeka artık sadece teorik bir alan olmaktan çıkıp günlük hayatımızın ayrılmaz bir parçası haline geldi. Sağlık sektöründen otomotive, eğitimden finansal analizlere kadar birçok alanda yapay zeka çözümleri aktif olarak kullanılmakta. Örneğin, hastalıkların erken teşhisi için geliştirilen yapay zeka tabanlı sistemler, doktorların işini kolaylaştırırken, hata oranını da ciddi şekilde azaltıyor. Öte yandan, otonom araçlar, sürücüsüz ulaşımın kapılarını aralarken, doğal dil işleme ile geliştirilen chatbot ve dijital asistanlar, müşteri hizmetlerinde devrim yaratıyor. GPT-4 ve benzeri büyük dil modelleri, metin oluşturma, özetleme, çeviri gibi alanlarda insan performansına yakın sonuçlar veriyor. Bu gelişmeler, önümüzdeki yıllarda daha da hız kazanacak gibi görünüyor. Ancak etik ve güvenlik konuları da her zamankinden daha fazla önem taşıyor.",
                CategoryId = 1,
                ImageUrl ="https://images.pexels.com/photos/8386440/pexels-photo-8386440.jpeg\n",
                AuthorId = users[0].Id,
                CreatedAt = new DateTime(2024, 04, 01)
            },
            new()
            {
                Id = 2,
                Title = "Kapadokya Gezisi",
                Content =
                    "Kapadokya, Türkiye'nin en büyüleyici doğal güzelliklerinden biri olarak her yıl binlerce turisti kendine çekiyor. Geçtiğimiz hafta sonu gerçekleştirdiğim Kapadokya gezisi, adeta başka bir dünyaya yolculuk gibiydi. Peribacalarıyla ünlü bu bölge, tarih boyunca birçok medeniyete ev sahipliği yapmış. Göreme Açık Hava Müzesi, bölgedeki en dikkat çeken duraklardan biri. Eski dönemden kalma kaya kiliseler ve freskler, insanı derinden etkiliyor. Sabah erken saatlerde yapılan sıcak hava balonu turu ise geziye bambaşka bir boyut kazandırıyor. Gökyüzünden Kapadokya'yı izlemek, kelimelerle tarif edilemeyecek kadar etkileyiciydi. Ayrıca yerel mutfak da oldukça zengin; testi kebabı, çömlek fasulyesi gibi yöresel tatları denemek kesinlikle unutulmaz bir deneyim. Bölgede konaklama için ise taş oteller oldukça otantik ve konforlu. Bu gezi, hem doğa hem de kültür meraklıları için tam anlamıyla bir cennet niteliğinde. Kapadokya, her adımda yeni bir keşif sunuyor.",
                CategoryId = 2,
                ImageUrl = "https://images.pexels.com/photos/3889704/pexels-photo-3889704.jpeg\n",
                AuthorId = users[0].Id,
                CreatedAt = new DateTime(2024, 04, 02)
            },
            new()
            {
                Id = 3,
                Title = "İtalyan Mutfağı",
                Content =
                    "İtalyan mutfağı, dünya genelinde en çok sevilen ve en çok bilinen mutfaklardan biridir. Özellikle makarna ve pizza denilince ilk akla gelen ülke olan İtalya, aslında çok daha geniş bir lezzet yelpazesine sahiptir. Bölgesel farklılıklar mutfağa büyük çeşitlilik katıyor. Örneğin, kuzey bölgelerinde tereyağı ve kremalı soslar yaygınken, güneyde daha çok zeytinyağı ve domates bazlı soslar kullanılıyor. Risotto, lasagna, gnocchi gibi lezzetler İtalyan mutfağının temel taşları arasında yer alıyor. Ayrıca, zeytinyağı, sarımsak, taze otlar ve peynirler mutfağın vazgeçilmezleri arasında. Tatlılar da oldukça iddialı; tiramisu, panna cotta ve cannoli gibi lezzetler damakta iz bırakıyor. İtalyanlar yemek hazırlamayı bir sanat olarak görüyor ve bu da yemeğin lezzetine yansıyor. Her yemeğin ardında bir hikâye ve gelenek var. İtalyan mutfağını bu kadar özel yapan da, hem basit hem de derin bir lezzet anlayışına sahip olmasıdır. Yemek yemeyi değil, yaşamayı öğretiyor adeta.",
                CategoryId = 3,
                AuthorId = users[1].Id,
                CreatedAt = new DateTime(2024, 04, 03)
            },
            new()
            {
                Id = 4,
                Title = "Futbol Taktikleri",
                Content =
                    "Futbol, sadece fiziksel bir spor değil, aynı zamanda strateji ve zeka oyunudur. Modern futbolda taktik anlayışı her geçen gün evrilmekte. Artık takımlar sadece bireysel yeteneklere değil, sistemli oyun planlarına da büyük önem veriyor. 4-3-3, 3-5-2, 4-2-3-1 gibi dizilişler oyunun temposunu ve seyrini ciddi şekilde etkileyebiliyor. Örneğin, Pep Guardiola'nın pas oyunu (tiki-taka) ile Jurgen Klopp'un gegenpressing sistemi, farklı ama etkili futbol anlayışlarının örnekleri olarak öne çıkıyor. Takım savunması, alan daraltma, hızlı geçiş oyunları gibi detaylar, maçın kaderini belirleyebiliyor. Aynı zamanda bireysel rollerin doğru belirlenmesi de kritik. Bir orta saha oyuncusunun hem savunma hem hücumda aktif rol alabilmesi, takım dengesini doğrudan etkiliyor. Teknolojinin ilerlemesiyle birlikte analiz sistemleri ve veriye dayalı taktik geliştirme araçları da yaygınlaştı. Artık her antrenman, her maç, hatta her oyuncu hareketi detaylı analiz ediliyor. Taktik bilgi kadar uygulama becerisi de başarıda belirleyici oluyor.",
                CategoryId = 4,
                ImageUrl = "https://images.pexels.com/photos/46798/the-ball-stadion-football-the-pitch-46798.jpeg\n",
                AuthorId = users[1].Id,
                CreatedAt = new DateTime(2024, 04, 09)
            },
            new()
            {
                Id = 5,
                Title = "Tiyatro Festivali",
                Content =
                    "Bu yıl katıldığım tiyatro festivali, sanatın ve sahne performanslarının büyüsünü bir kez daha hissettirdi. Festival boyunca farklı ülkelerden gelen tiyatro topluluklarının sahnelediği oyunlar, seyircilere adeta kültürel bir yolculuk yaşattı. Klasik eserlerden modern oyunlara, her biri farklı mesajlar ve duygular barındıran performanslar izledik. Özellikle minimalist sahne tasarımları ve yaratıcı kostümler, oyuncuların performansını daha da öne çıkardı. Seyircilerle etkileşimli sahneler, tiyatronun canlı ve dinamik yapısını ortaya koydu. Ayrıca festival kapsamında düzenlenen atölye çalışmaları ve söyleşiler, tiyatroya ilgi duyanlar için büyük bir öğrenme fırsatı sundu. Sahne arkasındaki emek, ışık tasarımı, müzik kullanımı gibi detaylar da oldukça etkileyiciydi. Tiyatro, insan ruhuna dokunan en güçlü sanat dallarından biri. Bu festival, yalnızca oyun izlemek değil, aynı zamanda sanatın birleştirici ve düşündürücü gücüne tanık olmak açısından da çok anlamlıydı.",
                CategoryId = 5,
                AuthorId = users[2].Id,
                CreatedAt = new DateTime(2024, 04, 10)
            },
            new()
            {
                Id = 6,
                Title = "Dijital Dönüşüm",
                Content =
                    "Dijital dönüşüm, sadece bir teknoloji yenilenmesi değil, aynı zamanda kurumların iş yapış biçimlerini kökten değiştiren bir süreçtir. Özellikle pandemi sonrası hız kazanan bu dönüşüm, artık tüm sektörlerde kaçınılmaz hale gelmiş durumda. Bulut bilişim, yapay zeka, büyük veri ve nesnelerin interneti gibi teknolojiler, iş dünyasında yeni fırsatlar yaratıyor. Şirketler daha çevik, verimli ve müşteri odaklı olmak adına dijital altyapılarını yeniden yapılandırıyor. Örneğin, dijitalleşen bir müşteri hizmetleri birimi, hem maliyetleri düşürürken hem de müşteri memnuniyetini artırabiliyor. Aynı zamanda çalışanlar için de daha esnek ve verimli bir iş ortamı sağlanıyor. Ancak bu dönüşüm sürecinde siber güvenlik, veri gizliliği ve çalışan eğitimi gibi konular da büyük önem taşıyor. Dijital dönüşüm sadece teknolojik değil, kültürel bir değişimi de beraberinde getiriyor. Kurumların bu değişime ayak uydurabilmesi, rekabet avantajı kazanmaları için kritik bir faktör. Bu nedenle dijital dönüşüm bir seçenek değil, bir zorunluluktur.",
                CategoryId = 1,
                AuthorId = users[2].Id,
                CreatedAt = new DateTime(2024, 04, 13)
            }
        };


        builder.Entity<Blog>().HasData(blogs);

        // Seed Comments
        var comments = new List<Comment>
        {
            new()
            {
                Id = 1,
                CommentText = "Harika bir yazı olmuş!",
                BlogId = 1,
                UserId = users[1].Id,
                CreatedAt = new DateTime(2024, 04, 04)
            },
            new()
            {
                Id = 2,
                CommentText = "Çok faydalı bilgiler.",
                BlogId = 1,
                UserId = users[2].Id,
                CreatedAt = new DateTime(2024, 04, 03)
            },
            new()
            {
                Id = 3,
                CommentText = "Ben de gitmeyi düşünüyorum.",
                BlogId = 2,
                UserId = users[2].Id,
                CreatedAt = new DateTime(2024, 04, 13)
            }
        };
        builder.Entity<Comment>().HasData(comments);
    }
}
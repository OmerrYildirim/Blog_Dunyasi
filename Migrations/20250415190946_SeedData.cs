using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DogusProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a"), 0, "STATICSTAMP1", "ahmet@example.com", true, false, null, "AHMET@EXAMPLE.COM", "AHMET.YILMAZ", "AQAAAAIAAYagAAAAEG3ZzqZ5Ez0XdbM7HzBDtLXMDF54QF9d54YbZlMYU1JArXs1xDBSMV5n25fu+RI1fQ==", null, false, "STATICSTAMP1", false, "ahmet.yilmaz" },
                    { new Guid("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b"), 0, "STATICSTAMP2", "mehmet@example.com", true, false, null, "MEHMET@EXAMPLE.COM", "MEHMET.KAYA", "AQAAAAIAAYagAAAAEP1JYtdUqMeQOB9b3oPO3ReAOtbvU1GNlU55L8w5gAuI8lF0ZXwGlCmG9R2SvdvVaQ==", null, false, "STATICSTAMP2", false, "mehmet.kaya" },
                    { new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c"), 0, "STATICSTAMP3", "ayse@example.com", true, false, null, "AYSE@EXAMPLE.COM", "AYSE.DEMIR", "AQAAAAIAAYagAAAAEMU1Uw2hAeGlObBGImMychTuM6Q4syuUw19GMymGkTLc4eXsLT+bN9iF4HTuATlMBw==", null, false, "STATICSTAMP3", false, "ayse.demir" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "Seyahat" },
                    { 3, "Yemek" },
                    { 4, "Spor" },
                    { 5, "Kültür-Sanat" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CommentId", "Content", "CreatedAt", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a"), 1, 0, "Son yıllarda yapay zeka (YZ) alanında yaşanan gelişmeler, teknoloji dünyasında devrim niteliğinde değişimlere yol açtı. Derin öğrenme, makine öğrenimi ve doğal dil işleme konularındaki ilerlemeler sayesinde, yapay zeka artık sadece teorik bir alan olmaktan çıkıp günlük hayatımızın ayrılmaz bir parçası haline geldi. Sağlık sektöründen otomotive, eğitimden finansal analizlere kadar birçok alanda yapay zeka çözümleri aktif olarak kullanılmakta. Örneğin, hastalıkların erken teşhisi için geliştirilen yapay zeka tabanlı sistemler, doktorların işini kolaylaştırırken, hata oranını da ciddi şekilde azaltıyor. Öte yandan, otonom araçlar, sürücüsüz ulaşımın kapılarını aralarken, doğal dil işleme ile geliştirilen chatbot ve dijital asistanlar, müşteri hizmetlerinde devrim yaratıyor. GPT-4 ve benzeri büyük dil modelleri, metin oluşturma, özetleme, çeviri gibi alanlarda insan performansına yakın sonuçlar veriyor. Bu gelişmeler, önümüzdeki yıllarda daha da hız kazanacak gibi görünüyor. Ancak etik ve güvenlik konuları da her zamankinden daha fazla önem taşıyor.", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.pexels.com/photos/8386440/pexels-photo-8386440.jpeg\n", "Yapay Zeka Gelişmeleri" },
                    { 2, new Guid("1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a"), 2, 0, "Kapadokya, Türkiye'nin en büyüleyici doğal güzelliklerinden biri olarak her yıl binlerce turisti kendine çekiyor. Geçtiğimiz hafta sonu gerçekleştirdiğim Kapadokya gezisi, adeta başka bir dünyaya yolculuk gibiydi. Peribacalarıyla ünlü bu bölge, tarih boyunca birçok medeniyete ev sahipliği yapmış. Göreme Açık Hava Müzesi, bölgedeki en dikkat çeken duraklardan biri. Eski dönemden kalma kaya kiliseler ve freskler, insanı derinden etkiliyor. Sabah erken saatlerde yapılan sıcak hava balonu turu ise geziye bambaşka bir boyut kazandırıyor. Gökyüzünden Kapadokya'yı izlemek, kelimelerle tarif edilemeyecek kadar etkileyiciydi. Ayrıca yerel mutfak da oldukça zengin; testi kebabı, çömlek fasulyesi gibi yöresel tatları denemek kesinlikle unutulmaz bir deneyim. Bölgede konaklama için ise taş oteller oldukça otantik ve konforlu. Bu gezi, hem doğa hem de kültür meraklıları için tam anlamıyla bir cennet niteliğinde. Kapadokya, her adımda yeni bir keşif sunuyor.", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.pexels.com/photos/3889704/pexels-photo-3889704.jpeg\n", "Kapadokya Gezisi" },
                    { 3, new Guid("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b"), 3, 0, "İtalyan mutfağı, dünya genelinde en çok sevilen ve en çok bilinen mutfaklardan biridir. Özellikle makarna ve pizza denilince ilk akla gelen ülke olan İtalya, aslında çok daha geniş bir lezzet yelpazesine sahiptir. Bölgesel farklılıklar mutfağa büyük çeşitlilik katıyor. Örneğin, kuzey bölgelerinde tereyağı ve kremalı soslar yaygınken, güneyde daha çok zeytinyağı ve domates bazlı soslar kullanılıyor. Risotto, lasagna, gnocchi gibi lezzetler İtalyan mutfağının temel taşları arasında yer alıyor. Ayrıca, zeytinyağı, sarımsak, taze otlar ve peynirler mutfağın vazgeçilmezleri arasında. Tatlılar da oldukça iddialı; tiramisu, panna cotta ve cannoli gibi lezzetler damakta iz bırakıyor. İtalyanlar yemek hazırlamayı bir sanat olarak görüyor ve bu da yemeğin lezzetine yansıyor. Her yemeğin ardında bir hikâye ve gelenek var. İtalyan mutfağını bu kadar özel yapan da, hem basit hem de derin bir lezzet anlayışına sahip olmasıdır. Yemek yemeyi değil, yaşamayı öğretiyor adeta.", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İtalyan Mutfağı" },
                    { 4, new Guid("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b"), 4, 0, "Futbol, sadece fiziksel bir spor değil, aynı zamanda strateji ve zeka oyunudur. Modern futbolda taktik anlayışı her geçen gün evrilmekte. Artık takımlar sadece bireysel yeteneklere değil, sistemli oyun planlarına da büyük önem veriyor. 4-3-3, 3-5-2, 4-2-3-1 gibi dizilişler oyunun temposunu ve seyrini ciddi şekilde etkileyebiliyor. Örneğin, Pep Guardiola'nın pas oyunu (tiki-taka) ile Jurgen Klopp'un gegenpressing sistemi, farklı ama etkili futbol anlayışlarının örnekleri olarak öne çıkıyor. Takım savunması, alan daraltma, hızlı geçiş oyunları gibi detaylar, maçın kaderini belirleyebiliyor. Aynı zamanda bireysel rollerin doğru belirlenmesi de kritik. Bir orta saha oyuncusunun hem savunma hem hücumda aktif rol alabilmesi, takım dengesini doğrudan etkiliyor. Teknolojinin ilerlemesiyle birlikte analiz sistemleri ve veriye dayalı taktik geliştirme araçları da yaygınlaştı. Artık her antrenman, her maç, hatta her oyuncu hareketi detaylı analiz ediliyor. Taktik bilgi kadar uygulama becerisi de başarıda belirleyici oluyor.", new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.pexels.com/photos/46798/the-ball-stadion-football-the-pitch-46798.jpeg\n", "Futbol Taktikleri" },
                    { 5, new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c"), 5, 0, "Bu yıl katıldığım tiyatro festivali, sanatın ve sahne performanslarının büyüsünü bir kez daha hissettirdi. Festival boyunca farklı ülkelerden gelen tiyatro topluluklarının sahnelediği oyunlar, seyircilere adeta kültürel bir yolculuk yaşattı. Klasik eserlerden modern oyunlara, her biri farklı mesajlar ve duygular barındıran performanslar izledik. Özellikle minimalist sahne tasarımları ve yaratıcı kostümler, oyuncuların performansını daha da öne çıkardı. Seyircilerle etkileşimli sahneler, tiyatronun canlı ve dinamik yapısını ortaya koydu. Ayrıca festival kapsamında düzenlenen atölye çalışmaları ve söyleşiler, tiyatroya ilgi duyanlar için büyük bir öğrenme fırsatı sundu. Sahne arkasındaki emek, ışık tasarımı, müzik kullanımı gibi detaylar da oldukça etkileyiciydi. Tiyatro, insan ruhuna dokunan en güçlü sanat dallarından biri. Bu festival, yalnızca oyun izlemek değil, aynı zamanda sanatın birleştirici ve düşündürücü gücüne tanık olmak açısından da çok anlamlıydı.", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tiyatro Festivali" },
                    { 6, new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c"), 1, 0, "Dijital dönüşüm, sadece bir teknoloji yenilenmesi değil, aynı zamanda kurumların iş yapış biçimlerini kökten değiştiren bir süreçtir. Özellikle pandemi sonrası hız kazanan bu dönüşüm, artık tüm sektörlerde kaçınılmaz hale gelmiş durumda. Bulut bilişim, yapay zeka, büyük veri ve nesnelerin interneti gibi teknolojiler, iş dünyasında yeni fırsatlar yaratıyor. Şirketler daha çevik, verimli ve müşteri odaklı olmak adına dijital altyapılarını yeniden yapılandırıyor. Örneğin, dijitalleşen bir müşteri hizmetleri birimi, hem maliyetleri düşürürken hem de müşteri memnuniyetini artırabiliyor. Aynı zamanda çalışanlar için de daha esnek ve verimli bir iş ortamı sağlanıyor. Ancak bu dönüşüm sürecinde siber güvenlik, veri gizliliği ve çalışan eğitimi gibi konular da büyük önem taşıyor. Dijital dönüşüm sadece teknolojik değil, kültürel bir değişimi de beraberinde getiriyor. Kurumların bu değişime ayak uydurabilmesi, rekabet avantajı kazanmaları için kritik bir faktör. Bu nedenle dijital dönüşüm bir seçenek değil, bir zorunluluktur.", new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dijital Dönüşüm" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogId", "CommentText", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Harika bir yazı olmuş!", new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b") },
                    { 2, 1, "Çok faydalı bilgiler.", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c") },
                    { 3, 2, "Ben de gitmeyi düşünüyorum.", new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b2b2b2b-2b2b-2b2b-2b2b-2b2b2b2b2b2b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3c3c3c3c-3c3c-3c3c-3c3c-3c3c3c3c3c3c"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a1a1a1a-1a1a-1a1a-1a1a-1a1a1a1a1a1a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

# yesil

"yesil"; Türkçe arayüzlü, çok platformlu (mobil ve masaüstü) kapsamlı bir sağlık ve yaşam koçu uygulamasıdır. Proje .NET MAUI altyapısı üzerine kurulu olup MVVM prensiplerini takip eder.

## Proje yapısı

```
src/Yesil
 ├── App.xaml                  # Uygulama kaynakları
 ├── AppShell.xaml             # Sekmeli navigasyon
 ├── Components/               # Yeniden kullanılabilir UI bileşenleri
 ├── Converters/               # XAML dönüştürücüleri
 ├── Models/                   # Veri modelleri ve kayıtları
 ├── Services/                 # İş mantığı ve veri servisleri
 ├── ViewModels/               # MVVM katmanı
 └── Views/                    # Türkçe arayüzlü sayfalar
```

## Öne çıkan özellikler

- **Beslenme modülü:** Besin değerleri, hormon etkileri, kimyasal içerikler, geleneksel ve modern tıp bilgileri, alışveriş listesi ve envanter yönetimi.
- **Egzersiz planlayıcı:** Dövüş ve extreme sporları içeren planlar, adım sayacı entegrasyonu ve günlük aktivite önerileri.
- **Sağlık takipleri:** Kan ve hormon değerleri, uyku analizi, hava durumu, vitamin eksikliği tahmini ve hedef/ödül sistemi.
- **Yapay zekâ ve topluluk:** Yapay zekâ önerileri, topluluk tavsiyeleri, doktor/diyetisyen desteği, psikolojik destek ve yaşam koçluğu.

## Başlangıç

1. **Önkoşullar:** .NET 8 SDK ve .NET MAUI iş yükü.
2. Depoyu klonlayın ve `src/Yesil/Yesil.csproj` projesini tercih ettiğiniz IDE (Visual Studio, Rider veya Visual Studio for Mac) ile açın.
3. Hedef platform için MAUI yapı profilini seçip uygulamayı çalıştırın.

> Not: Bu ortamda .NET SDK yüklü değildir; projeyi yerel geliştirme makinenizde derleyip çalıştırabilirsiniz.

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

1. **Önkoşullar:** .NET 9 SDK (9.0.306 veya uyumlu bir sonraki özellik sürümü) ve `dotnet workload install maui` ile yüklenmiş .NET MAUI iş yükü. MAUI paketleri workload tarafından sağlanır; projeye manuel olarak `Microsoft.Maui.*` NuGet paketleri eklemeniz gerekmez.
2. Kurulumu doğrulamak için terminalde `dotnet --info` komutunu çalıştırın; CLI'nin depo kökündeki `global.json` dosyasında belirtilen SDK sürümünü seçtiğini görmelisiniz.
3. Depoyu klonlayın ve `src/Yesil/Yesil.csproj` projesini tercih ettiğiniz IDE (Visual Studio, Rider veya Visual Studio for Mac) ile açın.
4. Hedef platform için MAUI yapı profilini seçip uygulamayı çalıştırın.

## Derleme ve test

Bu depo içerisinde otomatik bir test projesi bulunmamakla birlikte, temel doğrulamayı `dotnet build` komutuyla gerçekleştirebilirsiniz.

```bash
cd src/Yesil
dotnet build Yesil.csproj
```

İsteğe bağlı olarak, uygulamayı seçtiğiniz hedef platformda (Android, iOS, Mac Catalyst, Windows) emülatör ya da gerçek cihaz üzerinde çalıştırarak uçtan uca test yapabilirsiniz. MAUI önyükleme aşamasında hata almamak için gerekli emülatör/geliştirici sertifikası kurulumlarını tamamladığınızdan emin olun.

> Not: Bu ortamda .NET SDK yüklü değildir; projeyi yerel geliştirme makinenizde derleyip çalıştırabilirsiniz.

## Sorun giderme

- `Microsoft.Maui` veya `Microsoft.Maui.Controls` paketlerini 9.x sürümüyle bulamadığını belirten bir NuGet hatası görürseniz, MAUI iş yükü eksiktir. `dotnet workload install maui` komutunu çalıştırarak gerekli paketleri yükleyin ve projedeki manuel MAUI paket referanslarını eklemeyin.

# Longhorn Games Point & Click Test Case

## Core Mekanikler ve Tercihler

Projenin temel mekaniği (point & click) sistemi için Strategy Pattern kullanmayı tercih ettim. Strategy Pattern ile aynı tipte yeni nesneler eklemek ve bu nesnelerin davranışlarını değiştirip çeşitlendirmenin daha basit olacağını düşündüm. Alternatif olarak Command Pattern düşünmüştüm ancak Strategy Pattern’in bu proje için daha fazla esneklik sağladığına karar verdim.

Strategy'ler içinde UniTask kullandım, C#'ın standart Task yapısına göre daha performanslı ve hafif bir plugin olduğu için bunu tercih ettim.

## UI Yapısı

UI yapısını oluştururken MVP (Model-View-Presenter) modelini tercih ettim. Bu şekilde, UI bileşenlerini modüler hale getirerek daha kolay yönetilebilir bir yapı kurmayı hedefledim. Yeni UI eklemek ve yapı içerisindeki sorunları akışı takip ederek daha rahat bulabileceğimizi düşündüm. Ayrıca, Addressable sistemini de entegre ettim. Memory kullanımını azaltmak ve performansı artırmak amacıyla sadece ihtiyaç duyulan UI varlıklarının anlık olarak yüklenmesini amaçladım. Unity'deki asset’lerin memory’e yüklenmesini ve yönetilmesini bizim için daha optimize hale getirdiği için kullanmayı tercih ettim.

UI optimizasyonu için kullandığım sprite’ları SpriteAtlas haline getirerek batch sayısını olabildiğince az tutmaya çalıştım.

## Animasyonlar

UI ve objelerin animasyonu için DOTween kütüphanesini kullandım. Bu sayede, animasyonları daha esnek ve kontrol edilebilir bir hale getirmeyi amaçladım. Ayrıca karmaşık animasyonlar üzerinde daha fazla kontrol sağladığı için DoTween kullanmayı tercih ettim.

## Manager Yapısı

Projede, Manager sınıflarını genel olarak MonoBehaviour'dan türetmemeye özen gösterdim. MonoBehaviour'dan türetilmiş sınıflar, Unity'nin core metotlarını kullandığı için, bu durum bazen gereksiz bellek kullanımına ve performans kayıplarına yol açabiliyor. Bu nedenle, sadece ihtiyaç duyulan durumlarda MonoBehaviour kullanmaya dikkat ettim.

## Seviye Tasarımı

Her sahnenin farklı bir çevre tasarımına sahip olabileceğini göz önünde bulundurarak, her level'ı ayrı bir sahne olarak yapılandırmayı tercih ettim. Bu sayede, sahnelerin daha kolay yönetilmesini ve özelleştirilmesini amaçladım.

## Seviye Bitiş Koşulları

Level bitiş işlemleri için esnek bir sistem geliştirmek istedim. Bu yapı sayesinde, her bölüme kendine özgü LevelCompleteCondition sınıfından türetilmiş özel bitiş koşulları ekleyebiliriz. Örneğin, bir seviyede zaman sınırı, başka bir seviyede tıklama limiti gibi koşullar ekleyebilir veya bu koşulları birleştirebiliriz. Bu yapı sayesinde varyasyonları artırmayı amaçladım.

## Level Geçişleri

Yeni bölümleri yüklemek için, dökümantasyonda belirtilen yöntemden farklı olarak, level koşullarını dinleyip bir UI elementi çıkartmayı tercih ettim. Bu seçimin yapı için daha uygun olduğunu düşündüm. Ancak, mevcut sistemde kapı üzerine tıklayarak da level'ı bitirme işlemini çok kolay bir şekilde entegre etmek mümkündür. Case içerisinde çok kritik bir yere sahip olmadığını düşündüğüm için bu şekilde ilerledim, dilerseniz diğer varyasyonu da ekleyebilirim.

## Proje Genel Mimari ve Yapı

Projede genel olarak oyunun mimarisine odaklandım. UI/UX, animasyon, particle efektleri ve ses gibi polish odaklı unsurlar üzerinde, assetlerin yetersizliği nedeniyle fazla durmadım. Ancak bu sistemlerin temel altyapısını kurdum ve çalışır hale getirdim. Örneğin, ses ve müzik sistemi hazır durumdadır, ancak ses dosyaları henüz atanmadı. Bu sistemler, ileride yapılacak eklemelerle kolayca genişletilebilir haldedir.

## Sonuç ve Değerlendirme

Proje üzerinde yaklaşık 18 saat çalıştım. Daha fazla zaman ve gerekli assetler ile çok daha iyisini yapabileceğime inanıyorum. Bu case ile yeteneklerimi ve bilgi seviyemi hızlı bir şekilde gözlemleyebileceğiniz bir çalışma sunmayı amaçladım. Sürecin olumlu veya olumsuz sonuçlanmasından bağımsız, süreç sonunda eksiklerim hakkında geri bildirimde bulunmanız bana kendimi geliştirmem açısından çok faydalı olur. Umarım beğenirsiniz. Şimdiden teşekkür ederim.

# 🎨 كيف يعمل نظام التصميم (Theme) في nopCommerce

## 📂 هيكل المجلدات:

```
Presentation/Nop.Web/Themes/
└── DefaultClean/              ← اسم التصميم الحالي
    ├── theme.json            ← ملف تعريف التصميم
    ├── Content/
    │   ├── css/
    │   │   ├── styles.css    ← ملف CSS الرئيسي
    │   │   └── styles.rtl.css
    │   └── images/            ← الصور
    └── Views/                 ← ملفات Razor Views
        └── Shared/
            └── Head.cshtml    ← هنا يتم تحميل CSS
```

## 🔄 خطوات تحميل التصميم:

### 1️⃣ تحديد التصميم المستخدم:
- يتم تحديد التصميم من **Admin Panel** → **Configuration** → **Settings** → **General** → **Default store theme**
- أو من **Database** في جدول `Setting` → `DefaultStoreTheme`
- القيمة الحالية: `"DefaultClean"`

### 2️⃣ تحميل ملف CSS:
**الملف:** `Presentation/Nop.Web/Themes/DefaultClean/Views/Shared/Head.cshtml`

```csharp
var themeName = await themeContext.GetWorkingThemeNameAsync(); // "DefaultClean"
NopHtml.AppendCssFileParts($"~/Themes/{themeName}/Content/css/styles.css");
```

**النتيجة:** يتم تحميل الملف:
```
~/Themes/DefaultClean/Content/css/styles.css
```

### 3️⃣ ملف تعريف التصميم:
**الملف:** `Presentation/Nop.Web/Themes/DefaultClean/theme.json`

```json
{
  "SystemName": "DefaultClean",      ← الاسم المستخدم في الكود
  "FriendlyName": "Default clean",   ← الاسم المعروض في Admin
  "SupportRTL": true,
  "PreviewImageUrl": "~/Themes/DefaultClean/preview.jpg",
  "PreviewText": "The 'DefaultClean' site theme"
}
```

## 📍 أين يتم تحديد التصميم؟

### من Admin Panel:
1. اذهب إلى: **Admin Panel** → **Configuration** → **Settings** → **General**
2. ابحث عن: **"Default store theme"**
3. اختر التصميم المطلوب

### من Database:
```sql
SELECT * FROM [Setting] 
WHERE [Name] = 'StoreInformationSettings.DefaultStoreTheme'
```

القيمة ستكون: `"DefaultClean"`

## 🎯 الملفات الرئيسية:

### 1. ملف CSS الرئيسي:
```
Presentation/Nop.Web/Themes/DefaultClean/Content/css/styles.css
```
- هنا كل التصميم والألوان
- السطور 2-9: الألوان الأساسية (CSS Variables)

### 2. ملف تحميل CSS:
```
Presentation/Nop.Web/Themes/DefaultClean/Views/Shared/Head.cshtml
```
- هنا يتم تحديد أي ملف CSS يتم تحميله
- السطر 14: `NopHtml.AppendCssFileParts(...)`

### 3. ملف تعريف التصميم:
```
Presentation/Nop.Web/Themes/DefaultClean/theme.json
```
- معلومات التصميم الأساسية

## 🔧 كيفية تغيير التصميم:

### الطريقة 1: من Admin Panel (الأسهل)
1. Admin Panel → Configuration → Settings → General
2. Default store theme → اختر التصميم
3. Save

### الطريقة 2: تعديل الملفات مباشرة
1. افتح: `styles.css`
2. غيّر الألوان في السطور 2-9
3. احفظ الملف
4. أعد بناء المشروع

### الطريقة 3: إنشاء تصميم جديد
1. انسخ مجلد `DefaultClean`
2. غيّر الاسم (مثلاً: `MyCustomTheme`)
3. عدّل `theme.json` → `SystemName`
4. عدّل الملفات حسب الحاجة

## 💡 ملاحظات مهمة:

1. **الـ Theme محفوظ في Database** في جدول `Setting`
2. **الـ CSS يتم تحميله ديناميكياً** بناءً على اسم التصميم
3. **يمكن للعملاء اختيار التصميم** إذا كان مفعّل في Settings
4. **كل Store له تصميم خاص** (في حالة Multi-Store)

## 🎨 لتغيير الألوان فقط:

افتح: `Presentation/Nop.Web/Themes/DefaultClean/Content/css/styles.css`

غيّر في السطور 2-9:
```css
:root {
  --accent-blue-color: #4ab2f1;        ← غيّر هذا
  --accent-blue-active-color: #248ece; ← وغيّر هذا
}
```

## 📝 الخلاصة:

- **التصميم محفوظ في:** Database → `Setting` → `DefaultStoreTheme`
- **ملفات التصميم موجودة في:** `Presentation/Nop.Web/Themes/DefaultClean/`
- **ملف CSS الرئيسي:** `Content/css/styles.css`
- **يتم تحميله من:** `Views/Shared/Head.cshtml`


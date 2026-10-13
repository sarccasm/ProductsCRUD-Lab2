# Lab02 — Products CRUD (In-Memory)

Окремий навчальний проєкт ASP.NET Core MVC (.NET 8) для лабораторної роботи №2.

## Можливості

- Моделі `Product` (`Id`, `Name`, `Price`, `Description`, `CategoryId`) та `Category` (`Id`, `Name`).
- `IProductService` із асинхронними методами `GetAllAsync`, `GetByIdAsync`, `AddAsync`, `UpdateAsync`, `DeleteAsync`, `GetCategoriesAsync`.
- `InMemoryProductService`: два seed-товари, дві категорії, потокобезпечне зберігання через `lock` і статичний список, який ділиться між Scoped-екземплярами.
- CRUD у `ProductsController`, перевірки `ModelState.IsValid`, `ValidateAntiForgeryToken`.
- Вибір категорії у формах Create/Edit, серверна перевірка вибору, Razor Tag Helpers.
- Необов'язковий JSON API: `GET /products/1/info`.

## Запуск

Встановіть .NET 8 SDK, відкрийте каталог з `ProductsCRUD.csproj`:

```bash
dotnet restore
dotnet run --launch-profile http
```

Відкрийте http://localhost:5090/Products .

## Тестування CRUD

1. Відкрийте `/Products` і перевірте два seed-товари.
2. Create: додайте товар, оберіть категорію зі списку, збережіть.
3. Edit: змініть назву, ціну або категорію, переконайтеся, що оновлено.
4. Details: перевірте значення полів.
5. Delete: видаліть новий товар і переконайтеся, що він зник зі списку.
6. Спробуйте порожню назву, ціну 0 та відсутню категорію: форма має показувати помилки.
7. Відкрийте `/products/1/info` для JSON.

Дані зберігаються в оперативній пам'яті, тож після перезапуску повертається початковий набір.

## Git / здача в Moodle

Викладач просить **гілку `lab02` і Pull Request** до `main`. Гілку й PR потрібно створити у власному GitHub-репозиторії (їх не може містити ZIP сам по собі):

```bash
git checkout -b lab02
git add .
git commit -m "Implement lab02 products CRUD"
git push -u origin lab02
```

Після push створіть PR `lab02` → `main` на GitHub. Додайте реальні скриншоти Create, Edit, Details, Delete та списку товарів у PR/README. Скриншоти навмисно не підроблено й не вкладено до ZIP, оскільки їх слід зробити із запущеного застосунку.

> Лабораторна №1 та TriangleApp не змінюються. Якщо викладач вимагає саме продовжувати спільний репозиторій з lab01, окремий репозиторій формально відрізняється від цієї вимоги.

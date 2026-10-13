# Lab02 — Products CRUD (In-Memory)

Лабораторної роботи №2.

## Можливості

- Моделі `Product` (`Id`, `Name`, `Price`, `Description`, `CategoryId`) та `Category` (`Id`, `Name`).
- `IProductService` із асинхронними методами `GetAllAsync`, `GetByIdAsync`, `AddAsync`, `UpdateAsync`, `DeleteAsync`, `GetCategoriesAsync`.
- `InMemoryProductService`: два seed-товари, дві категорії, потокобезпечне зберігання через `lock` і статичний список, який ділиться між Scoped-екземплярами.
- CRUD у `ProductsController`, перевірки `ModelState.IsValid`, `ValidateAntiForgeryToken`.
- Вибір категорії у формах Create/Edit, серверна перевірка вибору, Razor Tag Helpers.
- Необов'язковий JSON API: `GET /products/1/info`.

<img width="2048" height="1280" alt="Screenshot 2026-10-13 at 09 23 58" src="https://github.com/user-attachments/assets/008ac6ee-7af9-491a-8f8d-63213e0a9fbc" />

﻿Приложение для поиска пользователями тату мастера
-----

## Тех-требования к реализации:

- Архитектура трехзвенная/онион.
- Все должно быть асинхронным.
- На каждом слое свои дто.
- Используем маппер.
- Логи через serilog/nlog пишем в файл и консоль.
- Пишем на каждую фичу тесты, используем xunit и moq.
- Все пишем на абстракциях, используем агрегацию.
- Сервисы/репозитории регистрируем через IoC контейнер.
- Для аутентификации и авторизации использовать JWT пока не будем делать рефреш токен, сделать его время жизни супер большим, может потом сделаем рефреш.
- Пароль в базе не храним, храним хеш пароля.
- Файлов в бд не должно быть, хранить их отдельно.
- С базой работаем через orm - любой.
- Бд mssql/postgres
- Подход code-first

## Ролевая модель:


<table>
<tr>
<td>client</td>
<td>У пользователя должно быть:
<ul>
<li>полное имя </li>
<li>номер телефона</li>
<li>аватар фотография необязательная</li>
</ul>
 Пользователь может:
 <ul>
 <li>зарегистрироваться в системе сам</li>
 <li>может искать тату мастера по стилям в которых он работает
   <ul>
   <li> по цене - сделать фильтры для поиска</li>
   <li>должна быть возможность посмотреть фотографии работ мастера по стилям</li>

   </ul>
 </li>
 <li>Пользователь может просматривать всех мастеров</li>
 <li>Пользователь может оставить заказ на татуировку у тату мастера только в свободную дату в расписании тату мастера.</li>
 <li>Просматривать статус своего заказа - подтвержден/отказано должен быть комментарий и текстовое поле в случае отказа, необязательное.</li>
 <li>Пользователь может отменить заказ если до даты заказа на татуировку осталось 2 дня.</li>
 <li>Пользователь на каждую дату может оставить заказ на татуировку. </li>
 </ul>
Отдавать эти данные на фронт с пагинацией<td>
</tr>
<tr>
<td>master</td>
<td>Должны быть обязательные:
<ul>
<li>контакты (номер телефона, соцсети)</li>
<li>обязательная фотография аватар</li>
<li>обязательный опыт в годах</li>
<li>имеет перечень стилей в которых он работает</li>
<li>Должны быть примеры работ в виде файлов изображений по конкретным стилям. (Ограничем пятью фотографиями)</li>
</ul>
Мастер сам:
<ul>
<li> выбирает стили из существующего списка (список пополняет администратор)</li>
<li> мастер устанавливает цену на сеанс в зависимости от стиля (предусмотреть какой то стандартный стиль, для базовой цены на сеанс)</li>
<li>У мастера должно быть расписание с актуальными датами</li>
</ul>
Дата брони\записи становиться недоступной только после подтверждения мастером (у мастера должен быть список заказов на татуировку, если в один и тот же день несколько заказов, мастер должен сам выбрать или отклонить заказ, как нибудь стоит их сгруппировать по датам). 
Cеанс не имеет точных временных значение - длиться 6-8 часов и в целом за один день может быть один сеанс.
</td>
</tr>
<tr>
<td>administrator</td>
<td>
<ul>
<li>
Может добавлять новых тату мастеров в систему (пусть будет вручную может расширим потом).</li>
<li>Может добавлять стили татуировок в которых работают мастера, может удалять или блокировать мастера, если мастер был заблокирован - его нельзя просматривать пользователям.</li>
</ul>
</td>
</tr>
</table>




 

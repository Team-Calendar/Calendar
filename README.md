2. Личен календар
Да се напише компютърна програма, реализираща информационна система, която поддържа личен календар. Програмата да поддържа текстов диалогов режим, позволяващ удобен интерактивен избор на следните операции:

запазване/отказване на час за среща. Записва се начало на среща (ден, час), край на среща, име (кратко описание - например "зъболекар”) и коментар
отпечатване на дневна програма, като по даден ден се извежда хронологичен списък с всички ангажименти за деня
промяна на часа и/или мястото на среща по име, като се запази останалата информация за събитието
търсене на среща: по име се извеждат останалите данни се срещата
намиране на свободно място за среща: по дадена начална дата и желана продължителност на срещата търси дата, на която е възможно да се запази такава среща, но само в работни дни и не преди 8 часа сутринта или след 5 часа вечерта.
намиране на свободно място за среща  по дадена начална дата, желана продължителност на срещата търси дата за запазване на такава среща, но само в работни дни и не преди 8 часа сутринта или след 5 часа вечерта

Пример:
Please choose what to do (1 - Create an event | 2 - Daily schedule | 3 - Search event | 4 - Find availability)
<< 1
Enter event name: 
<< Java lecture
Enter event date:
<< 17.06.2021
Enter start time: 
<< 18:00
Enter end time:
<< 20:00
Enter notes:
<< There will be project assignment at this lecture
Event was created succesfully!

Please choose what to do (1 - Create an event | 2 - Daily schedule | 3 - Search event | 4 - Find availability)
<< 2
Enter date: 
<< 10.06.2021
8:00 - 9:00 Sport: running
10:30 - 11:00 Daily team meeting
12:00 - 13:00 Lunch break: at Pizza Milevi
16:00 - 17:00 Technical planning: planning the release of next features

Please choose what to do (1 - Create an event | 2 - Daily schedule | 3 - Search event | 4 - Find availability)
<< 3
Enter event title: 
<<Dentist
25.05.2021 15:30 - 16:30 At the dentist: Fixing my teeth with caries
Do you want to Cancel or Edit event (1 - Cancel | 2 - Edit | press any other key to continue)
<< 1
Are you sure you want to cancel the event 25.05.2021 15:30 - 16:30 At the dentist: Fixing my teeth with caries? (Yes / Y)
<< Yes
Event was cancelled 

Please choose what to do (1 - Create an event | 2 - Daily schedule | 3 - Search event | 4 - Find availability)
<<4
Enter date: 
<< 20.06.2020
From time:
<< 13:00
Enter duration:
<< 2 
Available slot for the event: 20.06.2020 14:30

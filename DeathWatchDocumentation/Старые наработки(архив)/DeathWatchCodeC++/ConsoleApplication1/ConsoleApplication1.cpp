//Это тестовый набросок в рабочем состоянии.
// Требуется работа с цифрами и формулами, а так всё рабочее
#include <iostream>
#include <string>
using namespace std;

struct lfstyle {
    short int movements_stats, lifestyle, food;
    //Переменные для влияния на максимальное количество лет
};

struct age {
    short int age, age_end; // Переменные для возраста: первая для записи текущего количества лет, вторая для вычисления максимального возраста
    short int age_average; // Средний максимальный возраст
};

struct users {
    lfstyle MyStyle;
    age MyAge;
};

int main()
{
    users local_users; //Инициализация переменных и структур
    string answer_string;
    short int answer_num;
    short int i = 0; // Переменная для того, чтобы потом выбрать нужную формулу расчёта

    // Выясняем пол
    cout << "Are you a man or woman?" << endl;
    cin >> answer_string;
    if (answer_string == "woman") local_users.MyAge.age_average = 75;
    else if (answer_string == "man") local_users.MyAge.age_average = 70;

    // Сколько лет
    cout << "How old are you?" << endl;
    cin >> local_users.MyAge.age;

    // Насколько подвижен в ежедневном плане
    cout << "How much are you move every day? \t In kilometrs" << endl;
    cin >> answer_num;
    if (answer_num >= 10 ) {
        local_users.MyStyle.movements_stats = 4;
        i += 2;
    }
    else if (5 >= answer_num <= 9) {
        local_users.MyStyle.movements_stats = 2;
        i++;
    }
    else local_users.MyStyle.movements_stats = 1;

    // Здоровый или не очень образ жизни
    cout << "What lifestyle are you do?\t healful, average, not healful" << endl;
    cin >> answer_string;
    if (answer_string == "healful") {
        local_users.MyStyle.lifestyle = 1;
        i += 2;
    }
    else if (answer_string == "average") {
        local_users.MyStyle.lifestyle = 2;
        i++;
    }
    else local_users.MyStyle.lifestyle = 4;

    // Какую пищу употребляешь (какая преобладает)
    cout << "What do you eat? healful food or not? Answer /healful/, /average/ or /not/" << endl;
    cin >> answer_string;
    if (answer_string == "healful") {
        local_users.MyStyle.food = 1;
        i += 2;
    }
    else if (answer_string == "average") {
        local_users.MyStyle.food = 2;
        i++;
    }
    else local_users.MyStyle.food = 4;

    //Просчитываем
    if (i > 5) { // Как пример
        local_users.MyAge.age_end = local_users.MyAge.age_average + local_users.MyStyle.movements_stats
            + local_users.MyStyle.lifestyle + local_users.MyStyle.food;
    }
    else if (2 < i < 5) {
        local_users.MyAge.age_end = local_users.MyAge.age_average - local_users.MyStyle.movements_stats
            - local_users.MyStyle.lifestyle - local_users.MyStyle.food;
    }
    else {
        local_users.MyAge.age_end = local_users.MyAge.age_average + local_users.MyStyle.movements_stats
            + local_users.MyStyle.lifestyle - local_users.MyStyle.food;
    }
    cout << "\n You have max age: " << local_users.MyAge.age_end << "\n Already have: " << local_users.MyAge.age_end - local_users.MyAge.age;
}
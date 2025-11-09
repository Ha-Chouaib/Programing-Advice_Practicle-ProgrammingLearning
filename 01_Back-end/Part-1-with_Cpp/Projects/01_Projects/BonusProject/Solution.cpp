#include <iostream>
#include <cmath>
#include <cstdlib>
using namespace std;

enum enQuestionLevel{Easy=1, Med=2, Hard=3, Mix=4};
enum enOperationType{Add=1,Sub=2, Mult=3, Div=4, mix=5};

struct stQuizFinalResultInf
{
    string PassOrFail="";
    short QuestNumber=0;
    string QstLevelName="";
    char OperatorTypeName;
    short RightAnswerTimes=0, WroungAnswerTimes=0;

};
struct stQstInf
{
    short HowManyQsts=0;
    enQuestionLevel QuestionLevel;
    enOperationType OperationType;
    short Num1=0, Num2=0;
    int UserAnswer=0;
    int RightAnswer=0;
    string QstResult="";
    stQuizFinalResultInf FinalResultInf;
};

int ReadPositiveNumInRange(int From, int To,string Message)
{   int Num=0;
    do
    {
        cout<< Message <<endl;
        cin>> Num;

    } while (Num < From || Num > To);
    return Num;
}

int RandomNumberInRange(int From, int To)
{
    return rand()% (To - From +1) + From;
}

string Tabs(short HowManyTabs)
{   string Tab="";
    for(int tab=0; tab< HowManyTabs; tab++)
    {
        Tab+= '\t';
    }
    return Tab;
}

enQuestionLevel ReadQuestionLevel()
{            
    return (enQuestionLevel) ReadPositiveNumInRange(1,4,"Chose a Level: \\Easy-->[1]. \\Med-->[2]. \\Hard-->[3]. \\Mix-->[4].");

}

enOperationType ReadOperationType()
{
    return (enOperationType)ReadPositiveNumInRange(1,5,"Enter Optration Type: \\Add-->[1]. \\sub-->[2]. \\Mult-->[3]. \\Div-->[4]. \\Mix-->[5].");
}

char GetOperatorOption(stQstInf QstInf)
{
    switch (QstInf.OperationType)
        {
        case enOperationType::Add:
            return '+';
        case enOperationType::Sub:
            return '-';
        case enOperationType::Mult :
            return '*';
        case enOperationType::Div:
            return '/';    
        
        default:
            char RandOpt[4]={'+','-','*','/'};
            return RandOpt[RandomNumberInRange(0,3)];
            
        }
}

float RandomCalc(stQstInf QstInf)
{
    switch (QstInf.FinalResultInf.OperatorTypeName)
    {
    case '+':
        return QstInf.Num1 + QstInf.Num2;
    case '-':
        return QstInf.Num1 - QstInf.Num2;
    case '*':
        return QstInf.Num1 * QstInf.Num2;
    case '/':
        return QstInf.Num1 / QstInf.Num2;
    default:
        return QstInf.Num1 + QstInf.Num2;
        
    } 
   
}

float Calculator(stQstInf QstInf)
{
    switch (QstInf.OperationType)
        {
        case enOperationType::Add:
            return QstInf.Num1 + QstInf.Num2;
        case enOperationType::Sub:
            return QstInf.Num1 - QstInf.Num2;
        case enOperationType::Mult :
            return QstInf.Num1 * QstInf.Num2;
        case enOperationType::Div:
            return QstInf.Num1 / QstInf.Num2;    
        
        case enOperationType::mix:
            return RandomCalc(QstInf);

        default:
            return RandomCalc(QstInf);
        }
}

void QuestionResult(stQstInf& Qstinf)
{   cout<<Tabs(1)<<"------Question Result------"<<endl;
    if(Qstinf.UserAnswer == Qstinf.RightAnswer)
    {
        cout<<"Right Answer :)" <<endl;
        Qstinf.FinalResultInf.RightAnswerTimes++;
    }else
    {
        cout<<"Wrong Answer :( "<<endl;
        cout<<"The Right Answer is: "<<Qstinf.RightAnswer <<endl;
        Qstinf.FinalResultInf.WroungAnswerTimes ++;
    }
    cout<<Tabs(1)<<"-------------------------"<<endl;
}

string LevelOption(stQstInf& QstInf)
{
    switch (QstInf.QuestionLevel)
    {
    case enQuestionLevel::Easy:
        QstInf.Num1=RandomNumberInRange(1,10);
        QstInf.Num2=RandomNumberInRange(1,10); 

       return "Easy";

    case enQuestionLevel::Med:
        QstInf.Num1=RandomNumberInRange(10,50);
        QstInf.Num2=RandomNumberInRange(10,50);
        return " Meduim";

    case enQuestionLevel::Hard:
        QstInf.Num1=RandomNumberInRange(50,100);
        QstInf.Num2=RandomNumberInRange(50,100);
        return "Hard";
        
    case enQuestionLevel::Mix:
        QstInf.Num1=RandomNumberInRange(1,100);
        QstInf.Num2=RandomNumberInRange(1,100);
        return "Mix";
    default:
        return "Easy";
    }   

}

void ShowQuestion(stQstInf QstInf)
{
    cout<< QstInf.Num1<<endl;
    cout<< QstInf.Num2<<" "<< QstInf.FinalResultInf.OperatorTypeName <<endl;
    cout<<"______________________\n";
    
}

float GetUserAnswer()
{
    float Answer=0;
    cout<<"= ";
    cin>>Answer;
    cout<<endl;

    return  Answer;
}

void StartQuestion(stQstInf& QstInf)
{   
    QstInf.HowManyQsts=ReadPositiveNumInRange(1,100,"How Many Questions Do you Wanna Answer");
    QstInf.QuestionLevel=ReadQuestionLevel();
    QstInf.OperationType=ReadOperationType();

    for(int i=1; i<=QstInf.HowManyQsts; i++)
    {   cout<<"================Question[ "<< i <<"/"<<QstInf.HowManyQsts <<" ]==============="<<endl;
        QstInf.FinalResultInf.QuestNumber++;
       
        QstInf.FinalResultInf.QstLevelName=LevelOption(QstInf);
        QstInf.FinalResultInf.OperatorTypeName= GetOperatorOption(QstInf);
        ShowQuestion(QstInf);
        QstInf.UserAnswer= GetUserAnswer();
        QstInf.RightAnswer= Calculator(QstInf);
        QuestionResult(QstInf);
        cout<<"\n===============================================\n";

    }
}

void QuizResult(stQstInf QstInf)
{   cout<<"\n__________________Quiz Result___________________\n";
    cout<<"Number of Questions: "<< QstInf.FinalResultInf.QuestNumber <<endl;
    cout<<"Question Level: "<<QstInf.FinalResultInf.QstLevelName <<endl;
    cout<<"Operation Type: ( "<<QstInf.FinalResultInf.OperatorTypeName<<" )" <<endl;
    cout<<"Right Answers: " <<QstInf.FinalResultInf.RightAnswerTimes <<endl;
    cout<<"Wrong Answers: " <<QstInf.FinalResultInf.WroungAnswerTimes<<endl;
    cout<<"___________________________________________"<<endl;
}

string PassOrFail(stQstInf QstInf)
{
    if(QstInf.FinalResultInf.RightAnswerTimes > QstInf.FinalResultInf.WroungAnswerTimes)
        return "Pass :)";
    else if(QstInf.FinalResultInf.RightAnswerTimes < QstInf.FinalResultInf.WroungAnswerTimes)
        return "Fail :(";
    else
        return "Draw :|";
}

void EndOfQuiz(stQstInf QstInf)
{
    cout<<"\n+++++++++++End Session+++++++++++"<<endl;
    cout<<Tabs(1)<<"Final Result is:  "<<PassOrFail(QstInf) <<endl;
    cout<<"+++++++++++++++++++++++++++++++++"<<endl;
}

void StartQuiz()
{
    stQstInf QstInf;
    bool PlayAgain=true;
    do
    {   
        StartQuestion(QstInf);
        EndOfQuiz(QstInf);
        QuizResult(QstInf);
        PlayAgain=ReadPositiveNumInRange(0,1,"Do you wanna play again? Yes-->[1]\\No-->[0]");
    } while (PlayAgain);
    
}

int main()
{   srand((unsigned)time(NULL));

    StartQuiz();
    return 0;
}
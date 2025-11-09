#include <iostream>
#include <string>
#include <cmath>
#include <cstdlib>
using namespace std;

//Stone_Paper_Scissor ###

enum enGameOptions{Stone=1, Paper=2, Scissor=3};
struct stGameInf
{
    short HowManyRounds=0;
    enGameOptions UserOptions[100], ComputerOptions[100];
    unsigned short UserWinTimes=0, ComputerWinTimes=0, DrawTimes=0;
    string TheWinner="";


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

enGameOptions GetUserOption()
{   int Option=ReadPositiveNumInRange(1,3,"Get an Option: Stone-->[1] \\ Paper-->[2] \\ Scissor-->[3].\n");

    return  (enGameOptions)Option;
}

enGameOptions GetCoputerOption()
{
    return (enGameOptions) RandomNumberInRange(1,3);
}


void GameRounds(stGameInf GameInf)
{
    for(int i=0; i< GameInf.HowManyRounds; i++)
    {
        GameInf.UserOptions[i]=GetUserOption();
        GameInf.ComputerOptions[i]=GetCoputerOption();

    }
}

string GamersChoice(enGameOptions GamerOption)
{   
   
        switch (GamerOption)
            {
            case enGameOptions::Paper :
                return "Paper";
            case enGameOptions::Stone :
                return "Stone";
            case enGameOptions::Scissor :
                return "Scissor";
            default:
                return "";

            }

    
}

string RoundWenner(stGameInf& GameInf,enGameOptions UserOpt, enGameOptions ComputerOpt)
{
    if(UserOpt == ComputerOpt)
    {
        GameInf.DrawTimes ++;
        return "[No Winner]";
    }else if(UserOpt== enGameOptions::Paper && ComputerOpt== enGameOptions::Stone )
    {   
        GameInf.UserWinTimes ++;
        return "[Player]"; 
    }else if(UserOpt== enGameOptions::Stone && ComputerOpt== enGameOptions::Scissor )
    {   
        GameInf.UserWinTimes ++;
        return "[Player]"; 
    }else if(UserOpt== enGameOptions::Scissor && ComputerOpt== enGameOptions::Paper )
    {   
        GameInf.UserWinTimes ++;
        return "[Player]"; 
    }else{
        GameInf.ComputerWinTimes++;
        return "[Computer]";
    }


}


void RoundResults(stGameInf& GameInf ,short i)
{
    
    
        cout<<"\n----------------Round["<< i+1 <<"] Result----------------\n";
        cout<<"-----Player Choice:     "<<GamersChoice(GameInf.UserOptions[i]) <<endl;
        cout<<"-----Computer Choice:   "<<GamersChoice(GameInf.ComputerOptions[i])<<endl;
        cout<<"-----Round Winner:      "<<RoundWenner(GameInf,GameInf.UserOptions[i],GameInf.ComputerOptions[i])<<"--"<<endl;
        cout<<"\n-----------------------------------------------\n";
    
}

void Game_Rounds(stGameInf& GameInf)
{
    for(int i=0; i<GameInf.HowManyRounds; i++)
    {   
        cout<<"=============== Rouund["<< i+1 <<"]Is Begins==============="<<endl;
        GameInf.UserOptions[i]=GetUserOption();
        GameInf.ComputerOptions[i]=GetCoputerOption();
        RoundResults(GameInf, i);
        cout<<"\n=============================================="<<endl;
        cout<< endl;
    
    }
}

void GameOver()
{
    cout<<"\n++++++++++++++++++++++++++++++++++++++++++\n";
    cout<<"             --G A M E  O V E R--             ";
    cout<<"\n++++++++++++++++++++++++++++++++++++++++++\n";
}
void Game_finalResult(stGameInf GameInf)
{
    
    GameOver();
    cout<<"\n--------------[Game Results]--------------\n";
    cout<<"Game Rounds: "<<GameInf.HowManyRounds<<endl;
    cout<<"Player win Times: "<<GameInf.UserWinTimes <<endl;
    cout<<"Computer win Times: "<<GameInf.ComputerWinTimes <<endl;
    cout<<"Draw Times: "<<GameInf.DrawTimes <<endl;

    if(GameInf.UserWinTimes > GameInf.ComputerWinTimes)
        cout<<"Final winner: [ Player ]";
    else if(GameInf.UserWinTimes < GameInf.ComputerWinTimes)
        cout<<"Final winner: [ Computer ]";
    else
        cout<<"Final winner: [ No wenner ]";
    
    cout<<endl <<endl;



}

void startGame()
{   stGameInf GameInfo;
    
    bool playAgain=true;
    do
    {
        cout<<"\nWellcome To the Stone_Paper_Scissor Game"<<endl;
        GameInfo.HowManyRounds=ReadPositiveNumInRange(1,10,"How Many rounds Do you wanna Play? From [1] to [10]");
        Game_Rounds(GameInfo);
        Game_finalResult(GameInfo);   

        playAgain=ReadPositiveNumInRange(0,1,"Do you Want Play again Yes-->[1];No-->[0]"); 
    } while (playAgain);
    
    
}



int main()
{   srand((unsigned)time(NULL));

    startGame();

    return 0;
}
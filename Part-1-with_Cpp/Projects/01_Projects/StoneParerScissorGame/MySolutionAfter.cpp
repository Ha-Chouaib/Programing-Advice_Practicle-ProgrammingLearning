#include <iostream>
#include <cstdlib>
using namespace std;

enum enGameOptions{Stone=1, Paper=2, Scissor=3};
enum enWinner{Player=1, Computer=2, Draw=3};

struct stRoundInf
{
    short HowManyRoud=0;
    enGameOptions PlayerOption;
    enGameOptions ComputerOption;
    enWinner Winner;
    string WinnerName="";

};

struct stGameResult
{
    short GameRounds=0, PlayerWinTimes=0, ComputerWinTimes=0, DrawTimes=0;
    enWinner GameWinner;
    string GameWinnerName="";

};

struct stGameInf
{   
    stRoundInf RoundInf;
    stGameResult GameResult;
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

enGameOptions PlayerOption()
{
     int Option=ReadPositiveNumInRange(1,3,"Get an Option: Stone-->[1] \\ Paper-->[2] \\ Scissor-->[3].\n");
    return  (enGameOptions)Option;

}

enGameOptions ComputerOption()
{
    return (enGameOptions) RandomNumberInRange(1,3); 
}

string GetOptionName(enGameOptions GamerOpt)
{   
    string Option[3]={"Stone", "Paper", "Scissor"};
    return Option[GamerOpt-1];
}

string roundWinner(stGameInf& GameInf)
{
    if(GameInf.RoundInf.PlayerOption == GameInf.RoundInf.ComputerOption)
    {
        GameInf.GameResult.DrawTimes+=1;
        return GameInf.RoundInf.WinnerName= "[ No Winner ]";

    }else if(GameInf.RoundInf.PlayerOption == enGameOptions::Paper && GameInf.RoundInf.ComputerOption == enGameOptions::Stone)
    {
        GameInf.GameResult.PlayerWinTimes+=1;
        return GameInf.RoundInf.WinnerName= "[ Player ]";

    }else if(GameInf.RoundInf.PlayerOption == enGameOptions::Stone && GameInf.RoundInf.ComputerOption == enGameOptions::Scissor)
    {
        GameInf.GameResult.PlayerWinTimes+=1;
        return GameInf.RoundInf.WinnerName= "[ Player ]";
    }else if(GameInf.RoundInf.PlayerOption == enGameOptions::Scissor && GameInf.RoundInf.ComputerOption == enGameOptions::Paper)
    {
        GameInf.GameResult.PlayerWinTimes+=1;
        return GameInf.RoundInf.WinnerName= "[ Player ]";
    }else
    {
        GameInf.GameResult.ComputerWinTimes +=1;
        return GameInf.RoundInf.WinnerName= "[ Computer ]";
    }
        
}

string Tabs(short HowManyTabs)
{   string Tab="";
    for(int tab=0; tab< HowManyTabs; tab++)
    {
        Tab+= '\t';
    }
    return Tab;
}

void WelcomeToGame()
{   
    cout<<Tabs(2)<<"============================================"<<endl;
    cout<<Tabs(3)<<"Welcome To Stone\\Papre\\Scissor Game."<<endl;
    cout<<Tabs(2)<<"============================================"<<endl;
}

void RoundResult(stGameInf GameInf,short RoundNum)
{   
    cout<<Tabs(3)<<"_____________Round[ "<<RoundNum <<" ]Result_____________"<<endl;

    cout<<Tabs(4)<<"Player Choice: "  << GetOptionName(GameInf.RoundInf.PlayerOption)    <<endl;
    cout<<Tabs(4)<<"Computer Choice: "<< GetOptionName(GameInf.RoundInf.ComputerOption)  <<endl;
    cout<<Tabs(4)<<"The Winner: "     << GameInf.RoundInf.WinnerName       <<endl;
    
    cout<<Tabs(3)<<"____________________________________________"<<endl;

}

void PlayRound(stGameInf& GameInf)
{
    
    GameInf.RoundInf.HowManyRoud=ReadPositiveNumInRange(1,10,"How many rounds do you Wanna Play? From 1 To 10");

    for(int Round=0; Round< GameInf.RoundInf.HowManyRoud; Round++)
    {   GameInf.GameResult.GameRounds++;
        cout<<endl;
        cout<<Tabs(2)<<"-----------Round[ "<<Round+1<<" ] Begins-----------"<<endl;
        GameInf.RoundInf.PlayerOption=PlayerOption();
        GameInf.RoundInf.ComputerOption=ComputerOption();
        GameInf.RoundInf.WinnerName= roundWinner(GameInf);
        RoundResult(GameInf, Round+1);
        cout<<Tabs(2)<<"-----------------------------------------"<<endl;
    
    }

}

void GameOver()
{   cout <<endl;
    cout << Tabs(2) <<"__________________________________________________________\n\n";
    cout << Tabs(4) << " +++ G a m e O v e r+++\n";
    cout << Tabs(2) <<"__________________________________________________________\n\n";
}

string GameWinner(stGameInf GameInf)
{
    if(GameInf.GameResult.PlayerWinTimes > GameInf.GameResult.ComputerWinTimes)
        return "[ Player ]";
    else if(GameInf.GameResult.PlayerWinTimes < GameInf.GameResult.ComputerWinTimes)
        return "[ Computer ]";
    else
        return "[No Winner]";
}


void Game_Result(stGameInf& GameInf)
{
    cout<<Tabs(2)<<"\n=================[Game Result]================="<<endl;
    cout<<"Rounds: [ "          <<GameInf.GameResult.GameRounds<<" ]"       <<endl;
    cout<<"Player win Times: "  <<GameInf.GameResult.PlayerWinTimes   <<endl;
    cout<<"Computer win Times: "<<GameInf.GameResult.ComputerWinTimes <<endl;
    cout<<"Draw Times: "<<GameInf.GameResult.DrawTimes <<endl;
    cout<<"The Winner: "<<GameWinner(GameInf) <<endl;
    cout<<Tabs(2)<<"\n================================================"<<endl;

}
void StartGame()
{   
    stGameInf GameInf;
    bool PlayAgain=true;
    WelcomeToGame();
    do
    {
        PlayRound(GameInf);
        GameOver();
        Game_Result(GameInf);

        PlayAgain=ReadPositiveNumInRange(0,1,"Do you wanna Play again \\Yes-->[1]\\No-->[0]");

    } while (PlayAgain);
    

}
int main()
{   srand((unsigned)time(NULL));

    StartGame();

    return 0;
}

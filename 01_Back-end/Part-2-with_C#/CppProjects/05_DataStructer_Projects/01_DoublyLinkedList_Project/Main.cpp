#include<iostream>
#include"clsDblLinkedList.h"

using namespace std;

int main()
{
    clsDblLinkedList<short>LinkedList;
    LinkedList.IsEmpty()?cout<<"\nEmpty List\n" : cout<<"\nNot Empty\n";

    cout<<"\nInsert(1) at Beginning:\n";
    LinkedList.InsertAtBeginning(1);
    LinkedList.PrintList();

    cout<<"\nInsert (3) at End\n";
    LinkedList.InsertAtEnd(3);
    LinkedList.PrintList();

    cout<<"\nInsert (2) After (1)"<<endl;
    clsDblLinkedList<short>::Node* N1 = LinkedList.FindNode(1);
    LinkedList.InsertAfter(N1, 2);
    LinkedList.PrintList();

    cout<<"\nInsert at End 4-5-6-7"<<endl;

    LinkedList.InsertAtEnd(4);
    LinkedList.InsertAtEnd(5);
    LinkedList.InsertAtEnd(6);
    LinkedList.InsertAtEnd(7);
    LinkedList.PrintList();

    cout<<"\nDelete First Node "<<endl;
    LinkedList.DeleteFirstNode();
    LinkedList.PrintList();

    cout<<"\nDelete Last Node\n";
    LinkedList.DeleteLastNode();
    LinkedList.PrintList();

    cout<<"\nDelete Node (5)\n";
    clsDblLinkedList<short>::Node *N2=LinkedList.FindNode(5);
    LinkedList.DeleteNode(N2);
    LinkedList.PrintList();

    cout<<"\nLinked List Size: "<<LinkedList.Size()<<endl;
    LinkedList.IsEmpty()?cout<<"\nEmpty List\n" : cout<<"\nList Not Empty\n";

    cout<<"\nGet Node By Index.\n";
    clsDblLinkedList<short>::Node *N3=LinkedList.GetNode(0);
    cout<<"Node With Index(0) Value= " <<N3->Value<<endl;

    cout<<"\nGet Item By Index.\n";
    cout<<"Item With Index(2) : " <<LinkedList.GetItem(2)<<endl;

    cout<<"\nUpdate Item with Index (1) By [100]"<<endl;
    (LinkedList.UpdateItem(1,100) == true) ?cout<<"Updated Successfully" : cout<<"Update Fiald !";
    LinkedList.PrintList();

    cout<<"Insert (200) After Node Index(1)"<<endl;
    LinkedList.InsertAfter(1,200);
    LinkedList.PrintList();



    return 0;
}
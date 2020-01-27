using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;
    enum States { beginning, team, beforeday, raid, end };

    public string team = "";
    public Boolean haveBerlin = false;

    States myState = States.beginning;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myState == States.beginning)
            stateBeginning();
        if (myState == States.team)
            stateTeamPicking();
        if (myState == States.beforeday)
            beforeDay();
        if (myState == States.raid)
            doRaid();
    }
    private void stateBeginning()
    {
        text.text = "Planujesz napad, zbierasz ludzi. Znajdujesz\n" +
            " się w apartamencie oddalonym od Meksyku o 15 kilometrów. \n" +
            "Naciśnij klawisz k, aby znaleźć ludzi, którzy pomogą ci w napadzie.\n";
        if (Input.GetKeyDown(KeyCode.K))
            myState = States.team;
    }
    private void stateTeamPicking()
    {
        text.text = "Masz do wyboru kilka osób, możesz wybrać maksymalnie 3 osoby.\n" +
            " Denver - Klawisz D | Tokyo - Klawisz T | Berlin - Klawisz B |\n" +
            " Nairobi - Klawisz N | Rio - Klawisz R | Helsinki - Klawisz H\n" +
            " Przykład: Denver, Tokyo, Berlin - DTB";
        if (team.Length == 3)
        {
            myState = States.beforeday;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            team += "D";
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            team += "T";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            team += "B";
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            team += "N";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            team += "R";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            team += "H";
        }
    }
    private void beforeDay()
    {
        text.text = "Drużyna kompletna! \n";
        if (team == "DTB" || team == "TDB" || team == "BTD" || team == "DBT" || team == "TBD" || team == "BDT")
        {
            team = "DTB";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Denvera, Tokyo i Berlina.";
        }

        else if (team == "DTN" || team == "TDN" || team == "NTD" || team == "DNT" || team == "TND" || team == "NDT")
        {
            team = "DTN";
            text.text = text.text + "Wybrales: Denvera, Tokyo i Nairobi.";
        }

        else if (team == "DTR" || team == "TDR" || team == "RTD" || team == "DRT" || team == "TRD" || team == "RDT")
        {
            team = "DTR";
            text.text = text.text + "Wybrales: Denvera, Tokyo i Rio.";
        }

        else if (team == "DTH" || team == "TDH" || team == "HTD" || team == "DHT" || team == "THD" || team == "HDT")
        {
            team = "DTH";
            text.text = text.text + "Wybrales: Denvera, Tokyo i Helsinki.";
        }

        else if (team == "BTN" || team == "TBN" || team == "NTB" || team == "BNT" || team == "TNB" || team == "NBT")
        {
            team = "BTN";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Berlina, Tokyo i Nairobi.";
        }

        else if (team == "BHN" || team == "HBN" || team == "NHB" || team == "BNH" || team == "HNB" || team == "NBH")
        {
            team = "BHN";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Berlina, Helsinki i Nairobi.";
        }

        else if (team == "BRH" || team == "RBH" || team == "RHB" || team == "BHR" || team == "HRB" || team == "HBR")
        {
            team = "BRH";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Berlina, Rio i Helsinki.";
        }

        else if (team == "BRN" || team == "RBN" || team == "NRB" || team == "BNR" || team == "RNB" || team == "NBR")
        {
            team = "BRN";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Berlina, Rio i Nairobi.";
        }

        else if (team == "TRH" || team == "RTH" || team == "RHT" || team == "THR" || team == "HRT" || team == "HTR")
        {
            team = "TRH";
            text.text = text.text + "Wybrales: Tokyo, Rio i Helsinki.";
        }

        else if (team == "HRN" || team == "RHN" || team == "NRH" || team == "HNR" || team == "RNH" || team == "NHR")
        {
            team = "HRN";
            text.text = text.text + "Wybrales: Helsinki, Rio i Nairobi.";
        }

        else if (team == "HBT" || team == "BHT" || team == "HTB" || team == "BTH" || team == "THB" || team == "TBH")
        {
            team = "HBT";
            haveBerlin = true;
            text.text = text.text + "Wybrales: Helsinki, Berlin i Tokyo.";
        }
        text.text = text.text + "\n Wciśnij klawisz k, aby wykonać napad!";
        if (Input.GetKeyDown(KeyCode.K))
            myState = States.raid;
    }

    private void doRaid()
    {
        text.text = "Udało wam się wejść do środka mennicy, \n" +
            "napotykacie jednak opór ze strony zakładników.\n";
        if (haveBerlin)
        {
            text.text = text.text + "Posiadasz w drużynie Berlina, który sprawia, że \n" +
                "zakładnicy uspokajają się i nastaje spokój.";
        }
        else
        {
            text.text = text.text + " Zakładnicy atakują Denvera, który\n" +
                "zabija jednego z nich.";
        }
    }
}

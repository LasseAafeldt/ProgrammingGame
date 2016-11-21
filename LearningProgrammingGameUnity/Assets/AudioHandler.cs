using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour {

    public static AudioClip wakeUpClip;
    public static AudioClip lookamodule1Editet;
	public static AudioClip hallEdited;
	public static AudioClip books;
	public static AudioClip wellDoneInOffice;
	public static AudioClip itIsCold;
	public static AudioClip didYouSeeThermometer;
	public static AudioClip bigRedButton;
	public static AudioClip officeFourStory;
	public static AudioClip rememberModule;
	public static AudioClip goToStorage;
	public static AudioClip awFred;
	public static AudioClip needOneMoreModule;
	public static AudioClip factoryControlRoom;
	public static AudioClip playerSolvesLastTask;
	public static AudioClip lastModuleOnBelt;
	public static AudioClip stopPushing;

	public static bool isWakeUpClip = false;
	public static bool isLookamodule1Editet = false;
	public static bool isHallEdited = false;
	public static bool isBooks = false;
	public static bool isWellDoneInOffice = false;
	public static bool isItIsCold = false;
	public static bool isDidYouSeeThermometer = false;
	public static bool isBigRedButton = false;
	public static bool isOfficeFourStory = false;
	public static bool isRememberModule = false;
	public static bool isGoToStorage = false;
	public static bool isAwFred = false;
	public static bool isNeedOneMoreModule = false;
	public static bool isFactoryControlRoom = false;
	public static bool isPlayerSolvesLastTask = false;
	public static bool isLastModuleOnBelt = false;
	public static bool isStopPushing = false;


    // Use this for initialization
    void Start () {
        wakeUpClip =  Resources.Load<AudioClip>("Audio/Wakeup");
        lookamodule1Editet = Resources.Load<AudioClip>("Audio/lookamodule1Editet");
		hallEdited = Resources.Load<AudioClip> ("Audio/hallEdited");
		books =  Resources.Load<AudioClip>("Audio/booksEdited");
		wellDoneInOffice =  Resources.Load<AudioClip>("Audio/welldoneinofficeEdited");
		itIsCold =  Resources.Load<AudioClip>("Audio/isitcoldEdited");
		didYouSeeThermometer =  Resources.Load<AudioClip>("Audio/didyouseethermometerEdited");
		bigRedButton =  Resources.Load<AudioClip>("Audio/bigredbuttonEdited");
		officeFourStory =  Resources.Load<AudioClip>("Audio/o4storyEdited");
		rememberModule =  Resources.Load<AudioClip>("Audio/remembermoduleEdited");
		goToStorage =  Resources.Load<AudioClip>("Audio/gotostorageEdited");
		awFred =  Resources.Load<AudioClip>("Audio/awFredEdited");
		needOneMoreModule =  Resources.Load<AudioClip>("Audio/needonemoremoduleEdited");
		factoryControlRoom =  Resources.Load<AudioClip>("Audio/factory_controlroomEdited");
		playerSolvesLastTask =  Resources.Load<AudioClip>("Audio/playersolveslasttaskEdited");
		lastModuleOnBelt =  Resources.Load<AudioClip>("Audio/lastmodulonbeltEdited");


		stopPushing = Resources.Load<AudioClip>("Audio/stoppushing");



    }

    // Update is called once per frame
    void Update () {
	}
}

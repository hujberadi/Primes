Prímszámokat felsoroló program
Fő funkció:
	A program bekér egy 2-nél nagyobb számot a felhasználótól, majd kiírja a számnál kisebb prímszámokat.
Használat:
	A felhasználó begépeli azt a maximális értéket, ameddig ki szeretné iratni a prímeket.
Működés:
	A program ezt követően elindít egy ciklust amely először feltölt egy listát az összes számmal, majd a gyorsabb futás érdekében több szálon kiszedegeti a listából a nem prím elemeket. Ezt követően kiírja a lista tartalmát, amelyek között már csak a prímszámok maradtak meg.
Prímtesztelés módszere:
	A program a hagyományos brute-force eljárást használja, vagyis végig nézi minden egyes számmal az oszthatóságot 2-től egészen a szám négyzetgyökéig. Amennyiben talál osztót rögtön kiugrik a ciklusból, így nem fogyaszt felesleges erőforrást. Tulajdonképpen ez a rész az, amit a program több szálon végez, mivel ezek egymástól független folyamatok. Egyedül a listából való törlés során van szükség a szálak futásának felfüggesztésére.
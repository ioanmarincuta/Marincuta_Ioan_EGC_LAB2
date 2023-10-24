# Raspunsuri laborator 2 

3.
	Ce este un viewport?
Viewport-ul stabilește o regiune aflată la coordonate specifice în spațiul ecranului sau ferestrei unde se va desena conținutul grafic. Viewport-urile pot fi configurate pentru a specifica coordonatele și dimensiunile lor pe ecran sau în fereastră, precum și pentru a determina transformări sau efecte specifice care se aplică conținutului din interiorul lor.

 	Ce reprezintă conceptul de frames per seconds din punctul devedere al bibliotecii OpenGL?
Conceptul de frames per second se referă la numărul de cadre sau imagini randate pe ecran în fiecare secundă.

 	Când este rulată metoda OnUpdateFrame()?
OnUpdateFrame() este o metodă care este apelată în fiecare cadru (frame) al aplicației OpenGL și este utilizată pentru a actualiza starea aplicației înainte de randarea unui nou cadru; este apelată înainte de OnRenderFrame(), care este responsabilă de randarea cadrelor.

	 Ce este modul imediat de randare?
Modul imediat de randare este un stil de randare în grafica 3D în care fiecare comandă sau obiect de randare este desenat direct și imediat pe ecran, fără a utiliza o structură de date sau un buffer intermediar.

	Care este ultima versiune de OpenGL care acceptă modul imediat?
	OpenGL 3.0

	Când este rulată metoda OnRenderFrame()?
Metoda OnRenderFrame() este rulată în cadrul unui program OpenGL în timpul fiecărui cadru de randare.

	De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda OnResize() este utilizată pentru a gestiona schimbările de dimensiune ale fereastrei sau a contextului de randare OpenGL și este necesară să se ajusteze contextul OpenGL și viewport-ul pentru a se potrivi noilor dimensiuni ale ferestrei, în caz de redimensionare a acesteia de către utilizator.

 	Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
Fov (Field of View): Acesta reprezintă unghiul de vedere  și se măsoară de obicei în grade. Este unghiul sub care este văzută scena 3D din punctul de observare sau din camera virtuală. Domeniul obișnuit pentru acest parametru este între 1 și 180 grade.
Aspect Ratio: Aspectul reprezintă raportul dintre lățimea și înălțimea ferestrei sau a ecranuluiAspectul trebuie să fie un număr pozitiv.
Near Clipping Plane: Acesta reprezintă planul de apropiere al perspectivei și controlează ce obiecte sunt vizibile din punctul de observare. Obiectele mai apropiate decât acest plan sunt ascunse. Valoarea pentru acest plan trebuie să fie un număr pozitiv și diferit de zero.
Far Clipping Plane: reprezintă planul de departe al perspectivei și controlează cât de departe sunt vizibile obiectele.
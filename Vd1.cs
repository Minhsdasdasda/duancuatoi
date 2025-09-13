// sua mot chut khong dang ke
import java.util.*;

// ====== ENTITY CLASSES ======
class Student {
    String id;
    String name;
    int age;
    double gpa;

    Student(String id, String name, int age, double gpa) {
        this.id = id; this.name = name; this.age = age; this.gpa = gpa;
    }

    public String toString() {
        return String.format("ID:%s | Name:%s | Age:%d | GPA:%.2f", id, name, age, gpa);
    }
}

class Teacher {
    String id, name, major;

    Teacher(String id, String name, String major) {
        this.id = id; this.name = name; this.major = major;
    }

    public String toString() {
        return String.format("ID:%s | Name:%s | Major:%s", id, name, major);
    }
}

class Course {
    String id, name;
    int credits;

    Course(String id, String name, int credits) {
        this.id = id; this.name = name; this.credits = credits;
    }

    public String toString() {
        return String.format("ID:%s | Name:%s | Credits:%d", id, name, credits);
    }
}

class Enrollment {
    String studentId, courseId;

    Enrollment(String sid, String cid) {
        this.studentId = sid; this.courseId = cid;
    }

    public String toString() {
        return String.format("Student:%s -> Course:%s", studentId, courseId);
    }
}

class Grade {
    String studentId, courseId;
    double score;

    Grade(String sid, String cid, double score) {
        this.studentId = sid; this.courseId = cid; this.score = score;
    }

    public String toString() {
        return String.format("Student:%s | Course:%s | Score:%.2f", studentId, courseId, score);
    }
}

// ====== MANAGER CLASSES ======
class StudentManager {
    List<Student> list = new ArrayList<>();

    void add(Student s) { list.add(s); }
    void remove(String id) { list.removeIf(x -> x.id.equals(id)); }
    void update(String id, String name, int age, double gpa) {
        for (Student s : list) if (s.id.equals(id)) { s.name = name; s.age = age; s.gpa = gpa; }
    }
    void displayAll() { list.forEach(System.out::println); }
    void findByName(String name) { list.stream().filter(s -> s.name.equalsIgnoreCase(name)).forEach(System.out::println); }
    void findExcellent() { list.stream().filter(s -> s.gpa > 8).forEach(System.out::println); }
    void sortByName() { list.sort(Comparator.comparing(s -> s.name)); }
    void sortByGpaDesc() { list.sort((a, b) -> Double.compare(b.gpa, a.gpa)); }
}

class TeacherManager {
    List<Teacher> list = new ArrayList<>();
    void add(Teacher t) { list.add(t); }
    void remove(String id) { list.removeIf(x -> x.id.equals(id)); }
    void update(String id, String name, String major) {
        for (Teacher t : list) if (t.id.equals(id)) { t.name = name; t.major = major; }
    }
    void displayAll() { list.forEach(System.out::println); }
}

class CourseManager {
    List<Course> list = new ArrayList<>();
    void add(Course c) { list.add(c); }
    void remove(String id) { list.removeIf(x -> x.id.equals(id)); }
    void update(String id, String name, int credits) {
        for (Course c : list) if (c.id.equals(id)) { c.name = name; c.credits = credits; }
    }
    void displayAll() { list.forEach(System.out::println); }
}

class EnrollmentManager {
    List<Enrollment> list = new ArrayList<>();
    void add(Enrollment e) { list.add(e); }
    void remove(String sid, String cid) { list.removeIf(x -> x.studentId.equals(sid) && x.courseId.equals(cid)); }
    void displayAll() { list.forEach(System.out::println); }
}

class GradeManager {
    List<Grade> list = new ArrayList<>();
    void add(Grade g) { list.add(g); }
    void update(String sid, String cid, double score) {
        for (Grade g : list) if (g.studentId.equals(sid) && g.courseId.equals(cid)) g.score = score;
    }
    void displayAll() { list.forEach(System.out::println); }
}

// ====== MAIN APP ======
public class SchoolApp {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        StudentManager sm = new StudentManager();
        TeacherManager tm = new TeacherManager();
        CourseManager cm = new CourseManager();
        EnrollmentManager em = new EnrollmentManager();
        GradeManager gm = new GradeManager();

        int menu = 0;
        while (menu != 99) {
            System.out.println("============= MENU =============");
            System.out.println("1. Quan ly Sinh vien");
            System.out.println("2. Quan ly Giao vien");
            System.out.println("3. Quan ly Mon hoc");
            System.out.println("4. Quan ly Dang ky");
            System.out.println("5. Quan ly Diem");
            System.out.println("6. Bao cao tong hop");
            System.out.println("99. Thoat");
            System.out.print("Nhap lua chon: ");
            menu = Integer.parseInt(sc.nextLine());

            switch (menu) {
                case 1 -> studentMenu(sc, sm);
                case 2 -> teacherMenu(sc, tm);
                case 3 -> courseMenu(sc, cm);
                case 4 -> enrollmentMenu(sc, em);
                case 5 -> gradeMenu(sc, gm);
                case 6 -> report(sm, cm, em, gm);
            }
        }
    }

    // ====== SUB MENUS ======
    static void studentMenu(Scanner sc, StudentManager sm) {
        int ch=0;
        while (ch!=9) {
            System.out.println("--- STUDENT MENU ---");
            System.out.println("1.Them  2.Xoa  3.Cap nhat  4.Hien thi  5.Tim ten  6.GPA>8  7.Sort Name  8.Sort GPA  9.Back");
            ch=Integer.parseInt(sc.nextLine());
            switch(ch){
                case 1 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String name=sc.nextLine();
                            System.out.print("Age:"); int age=Integer.parseInt(sc.nextLine());
                            System.out.print("GPA:"); double gpa=Double.parseDouble(sc.nextLine());
                            sm.add(new Student(id,name,age,gpa)); }
                case 2 -> { System.out.print("ID:"); sm.remove(sc.nextLine()); }
                case 3 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String name=sc.nextLine();
                            System.out.print("Age:"); int age=Integer.parseInt(sc.nextLine());
                            System.out.print("GPA:"); double gpa=Double.parseDouble(sc.nextLine());
                            sm.update(id,name,age,gpa); }
                case 4 -> sm.displayAll();
                case 5 -> { System.out.print("Name:"); sm.findByName(sc.nextLine()); }
                case 6 -> sm.findExcellent();
                case 7 -> sm.sortByName();
                case 8 -> sm.sortByGpaDesc();
            }
        }
    }

    static void teacherMenu(Scanner sc, TeacherManager tm){
        int ch=0;
        while(ch!=9){
            System.out.println("--- TEACHER MENU ---");
            System.out.println("1.Them  2.Xoa  3.Cap nhat  4.Hien thi  9.Back");
            ch=Integer.parseInt(sc.nextLine());
            switch(ch){
                case 1 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String name=sc.nextLine();
                            System.out.print("Major:"); String m=sc.nextLine();
                            tm.add(new Teacher(id,name,m)); }
                case 2 -> { System.out.print("ID:"); tm.remove(sc.nextLine()); }
                case 3 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String n=sc.nextLine();
                            System.out.print("Major:"); String m=sc.nextLine();
                            tm.update(id,n,m); }
                case 4 -> tm.displayAll();
            }
        }
    }

    static void courseMenu(Scanner sc, CourseManager cm){
        int ch=0;
        while(ch!=9){
            System.out.println("--- COURSE MENU ---");
            System.out.println("1.Them  2.Xoa  3.Cap nhat  4.Hien thi  9.Back");
            ch=Integer.parseInt(sc.nextLine());
            switch(ch){
                case 1 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String n=sc.nextLine();
                            System.out.print("Credits:"); int c=Integer.parseInt(sc.nextLine());
                            cm.add(new Course(id,n,c)); }
                case 2 -> { System.out.print("ID:"); cm.remove(sc.nextLine()); }
                case 3 -> { System.out.print("ID:"); String id=sc.nextLine();
                            System.out.print("Name:"); String n=sc.nextLine();
                            System.out.print("Credits:"); int c=Integer.parseInt(sc.nextLine());
                            cm.update(id,n,c); }
                case 4 -> cm.displayAll();
            }
        }
    }

    static void enrollmentMenu(Scanner sc, EnrollmentManager em){
        int ch=0;
        while(ch!=9){
            System.out.println("--- ENROLLMENT MENU ---");
            System.out.println("1.Dang ky  2.Huy  3.Hien thi  9.Back");
            ch=Integer.parseInt(sc.nextLine());
            switch(ch){
                case 1 -> { System.out.print("SID:"); String sid=sc.nextLine();
                            System.out.print("CID:"); String cid=sc.nextLine();
                            em.add(new Enrollment(sid,cid)); }
                case 2 -> { System.out.print("SID:"); String sid=sc.nextLine();
                            System.out.print("CID:"); String cid=sc.nextLine();
                            em.remove(sid,cid); }
                case 3 -> em.displayAll();
            }
        }
    }

    static void gradeMenu(Scanner sc, GradeManager gm){
        int ch=0;
        while(ch!=9){
            System.out.println("--- GRADE MENU ---");
            System.out.println("1.Nhap diem  2.Cap nhat  3.Hien thi  9.Back");
            ch=Integer.parseInt(sc.nextLine());
            switch(ch){
                case 1 -> { System.out.print("SID:"); String sid=sc.nextLine();
                            System.out.print("CID:"); String cid=sc.nextLine();
                            System.out.print("Score:"); double d=Double.parseDouble(sc.nextLine());
                            gm.add(new Grade(sid,cid,d)); }
                case 2 -> { System.out.print("SID:"); String sid=sc.nextLine();
                            System.out.print("CID:"); String cid=sc.nextLine();
                            System.out.print("Score:"); double d=Double.parseDouble(sc.nextLine());
                            gm.update(sid,cid,d); }
                case 3 -> gm.displayAll();
            }
        }
    }

    // ====== REPORT ======
    static void report(StudentManager sm, CourseManager cm, EnrollmentManager em, GradeManager gm){
        System.out.println("=== BAO CAO ===");
        for(Student s: sm.list){
            System.out.println("Sinh vien: " + s.name);
            for(Enrollment e: em.list){
                if(e.studentId.equals(s.id)){
                    for(Course c: cm.list){
                        if(c.id.equals(e.courseId)){
                            System.out.print(" - Mon hoc: " + c.name);
                            for(Grade g: gm.list){
                                if(g.studentId.equals(s.id) && g.courseId.equals(c.id)){
                                    System.out.print(" | Diem: " + g.score);
                                }
                            }
                            System.out.println();
                        }
                    }
                }
            }
        }
    }
}


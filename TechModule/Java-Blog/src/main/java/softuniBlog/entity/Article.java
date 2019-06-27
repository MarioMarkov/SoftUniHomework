package softuniBlog.entity;

import javax.persistence.*;

import javax.validation.constraints.NotNull;

@Entity
@Table(name = "articles")
public class Article {
    private Integer id;
    private User author;
    private String content;
    private String title;

    public Article(){

    }
    public Article(String title, String content, User author){
        this.author = author;
        this.content = content;
        this.title = title;
    }


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }


    @ManyToOne()
    @JoinColumn(nullable = false, name = "authorId")
    public User getAuthor() {
        return author;
    }

    public void setAuthor(User author) {
        this.author = author;
    }

    @Column(columnDefinition = "text", nullable =false)
    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    @Column(nullable = false)
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
    @Transient
    public String getSummary(){
        return this.getContent().substring(0,this.getContent().length() /2)+ "...";
    }
}

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.persistence;

import java.io.Serializable;
import java.math.BigInteger;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Christian Richards
 */
@Entity
@Table(name = "aegis_born_character")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "AegisBornCharacter.findAll", query = "SELECT a FROM AegisBornCharacter a"),
    @NamedQuery(name = "AegisBornCharacter.findById", query = "SELECT a FROM AegisBornCharacter a WHERE a.id = :id"),
    @NamedQuery(name = "AegisBornCharacter.findByName", query = "SELECT a FROM AegisBornCharacter a WHERE a.name = :name"),
    @NamedQuery(name = "AegisBornCharacter.findBySex", query = "SELECT a FROM AegisBornCharacter a WHERE a.sex = :sex"),
    @NamedQuery(name = "AegisBornCharacter.findByClass1", query = "SELECT a FROM AegisBornCharacter a WHERE a.class1 = :class1"),
    @NamedQuery(name = "AegisBornCharacter.findByLevel", query = "SELECT a FROM AegisBornCharacter a WHERE a.level = :level"),
    @NamedQuery(name = "AegisBornCharacter.findByPositionX", query = "SELECT a FROM AegisBornCharacter a WHERE a.positionX = :positionX"),
    @NamedQuery(name = "AegisBornCharacter.findByPositionY", query = "SELECT a FROM AegisBornCharacter a WHERE a.positionY = :positionY"),
    @NamedQuery(name = "AegisBornCharacter.findByCreatedAt", query = "SELECT a FROM AegisBornCharacter a WHERE a.createdAt = :createdAt"),
    @NamedQuery(name = "AegisBornCharacter.findByUpdatedAt", query = "SELECT a FROM AegisBornCharacter a WHERE a.updatedAt = :updatedAt")})
public class AegisBornCharacter implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @NotNull
    @Column(name = "id")
    private Long id;
    @Size(max = 255)
    @Column(name = "name")
    private String name;
    @Size(max = 1)
    @Column(name = "sex")
    private String sex;
    @Size(max = 50)
    @Column(name = "class")
    private String class1;
    @Column(name = "level")
    private BigInteger level;
    @Column(name = "position_x")
    private BigInteger positionX;
    @Column(name = "position_y")
    private BigInteger positionY;
    @Basic(optional = false)
    @NotNull
    @Column(name = "created_at")
    @Temporal(TemporalType.TIMESTAMP)
    private Date createdAt;
    @Basic(optional = false)
    @NotNull
    @Column(name = "updated_at")
    @Temporal(TemporalType.TIMESTAMP)
    private Date updatedAt;
    @JoinColumn(name = "user_id", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private SfGuardUser userId;

    public AegisBornCharacter() {
    }

    public AegisBornCharacter(Long id) {
        this.id = id;
    }

    public AegisBornCharacter(Long id, Date createdAt, Date updatedAt) {
        this.id = id;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }

    public String getClass1() {
        return class1;
    }

    public void setClass1(String class1) {
        this.class1 = class1;
    }

    public BigInteger getLevel() {
        return level;
    }

    public void setLevel(BigInteger level) {
        this.level = level;
    }

    public BigInteger getPositionX() {
        return positionX;
    }

    public void setPositionX(BigInteger positionX) {
        this.positionX = positionX;
    }

    public BigInteger getPositionY() {
        return positionY;
    }

    public void setPositionY(BigInteger positionY) {
        this.positionY = positionY;
    }

    public Date getCreatedAt() {
        return createdAt;
    }

    public void setCreatedAt(Date createdAt) {
        this.createdAt = createdAt;
    }

    public Date getUpdatedAt() {
        return updatedAt;
    }

    public void setUpdatedAt(Date updatedAt) {
        this.updatedAt = updatedAt;
    }

    public SfGuardUser getUserId() {
        return userId;
    }

    public void setUserId(SfGuardUser userId) {
        this.userId = userId;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof AegisBornCharacter)) {
            return false;
        }
        AegisBornCharacter other = (AegisBornCharacter) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.cjrgaming.aegisborn.persistence.AegisBornCharacter[ id=" + id + " ]";
    }
    
}

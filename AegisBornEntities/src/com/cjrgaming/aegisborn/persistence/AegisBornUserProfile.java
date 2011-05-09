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
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Christian Richards
 */
@Entity
@Table(name = "aegis_born_user_profile")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "AegisBornUserProfile.findAll", query = "SELECT a FROM AegisBornUserProfile a"),
    @NamedQuery(name = "AegisBornUserProfile.findById", query = "SELECT a FROM AegisBornUserProfile a WHERE a.id = :id"),
    @NamedQuery(name = "AegisBornUserProfile.findByCharacterSlots", query = "SELECT a FROM AegisBornUserProfile a WHERE a.characterSlots = :characterSlots"),
    @NamedQuery(name = "AegisBornUserProfile.findByCreatedAt", query = "SELECT a FROM AegisBornUserProfile a WHERE a.createdAt = :createdAt"),
    @NamedQuery(name = "AegisBornUserProfile.findByUpdatedAt", query = "SELECT a FROM AegisBornUserProfile a WHERE a.updatedAt = :updatedAt")})
public class AegisBornUserProfile implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @NotNull
    @Column(name = "id")
    private Long id;
    @Column(name = "character_slots")
    private BigInteger characterSlots;
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

    public AegisBornUserProfile() {
    }

    public AegisBornUserProfile(Long id) {
        this.id = id;
    }

    public AegisBornUserProfile(Long id, Date createdAt, Date updatedAt) {
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

    public BigInteger getCharacterSlots() {
        return characterSlots;
    }

    public void setCharacterSlots(BigInteger characterSlots) {
        this.characterSlots = characterSlots;
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
        if (!(object instanceof AegisBornUserProfile)) {
            return false;
        }
        AegisBornUserProfile other = (AegisBornUserProfile) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.cjrgaming.aegisborn.persistence.AegisBornUserProfile[ id=" + id + " ]";
    }
    
}

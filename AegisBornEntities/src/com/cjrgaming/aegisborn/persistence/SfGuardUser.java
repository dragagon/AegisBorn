/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.cjrgaming.aegisborn.persistence;

import java.io.Serializable;
import java.util.Collection;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Christian Richards
 */
@Entity
@Table(name = "sf_guard_user")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "SfGuardUser.findAll", query = "SELECT s FROM SfGuardUser s"),
    @NamedQuery(name = "SfGuardUser.findById", query = "SELECT s FROM SfGuardUser s WHERE s.id = :id"),
    @NamedQuery(name = "SfGuardUser.findByFirstName", query = "SELECT s FROM SfGuardUser s WHERE s.firstName = :firstName"),
    @NamedQuery(name = "SfGuardUser.findByLastName", query = "SELECT s FROM SfGuardUser s WHERE s.lastName = :lastName"),
    @NamedQuery(name = "SfGuardUser.findByEmailAddress", query = "SELECT s FROM SfGuardUser s WHERE s.emailAddress = :emailAddress"),
    @NamedQuery(name = "SfGuardUser.findByUsername", query = "SELECT s FROM SfGuardUser s WHERE s.username = :username"),
    @NamedQuery(name = "SfGuardUser.findByAlgorithm", query = "SELECT s FROM SfGuardUser s WHERE s.algorithm = :algorithm"),
    @NamedQuery(name = "SfGuardUser.findBySalt", query = "SELECT s FROM SfGuardUser s WHERE s.salt = :salt"),
    @NamedQuery(name = "SfGuardUser.findByPassword", query = "SELECT s FROM SfGuardUser s WHERE s.password = :password"),
    @NamedQuery(name = "SfGuardUser.findByIsActive", query = "SELECT s FROM SfGuardUser s WHERE s.isActive = :isActive"),
    @NamedQuery(name = "SfGuardUser.findByIsSuperAdmin", query = "SELECT s FROM SfGuardUser s WHERE s.isSuperAdmin = :isSuperAdmin"),
    @NamedQuery(name = "SfGuardUser.findByLastLogin", query = "SELECT s FROM SfGuardUser s WHERE s.lastLogin = :lastLogin"),
    @NamedQuery(name = "SfGuardUser.findByCreatedAt", query = "SELECT s FROM SfGuardUser s WHERE s.createdAt = :createdAt"),
    @NamedQuery(name = "SfGuardUser.findByUpdatedAt", query = "SELECT s FROM SfGuardUser s WHERE s.updatedAt = :updatedAt")})
public class SfGuardUser implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @NotNull
    @Column(name = "id")
    private Long id;
    @Size(max = 255)
    @Column(name = "first_name")
    private String firstName;
    @Size(max = 255)
    @Column(name = "last_name")
    private String lastName;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 255)
    @Column(name = "email_address")
    private String emailAddress;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 128)
    @Column(name = "username")
    private String username;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 128)
    @Column(name = "algorithm")
    private String algorithm;
    @Size(max = 128)
    @Column(name = "salt")
    private String salt;
    @Size(max = 128)
    @Column(name = "password")
    private String password;
    @Column(name = "is_active")
    private Boolean isActive;
    @Column(name = "is_super_admin")
    private Boolean isSuperAdmin;
    @Column(name = "last_login")
    @Temporal(TemporalType.TIMESTAMP)
    private Date lastLogin;
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
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "userId")
    private Collection<AegisBornUserProfile> aegisBornUserProfileCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "userId")
    private Collection<AegisBornCharacter> aegisBornCharacterCollection;

    public SfGuardUser() {
    }

    public SfGuardUser(Long id) {
        this.id = id;
    }

    public SfGuardUser(Long id, String emailAddress, String username, String algorithm, Date createdAt, Date updatedAt) {
        this.id = id;
        this.emailAddress = emailAddress;
        this.username = username;
        this.algorithm = algorithm;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmailAddress() {
        return emailAddress;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getAlgorithm() {
        return algorithm;
    }

    public void setAlgorithm(String algorithm) {
        this.algorithm = algorithm;
    }

    public String getSalt() {
        return salt;
    }

    public void setSalt(String salt) {
        this.salt = salt;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Boolean getIsActive() {
        return isActive;
    }

    public void setIsActive(Boolean isActive) {
        this.isActive = isActive;
    }

    public Boolean getIsSuperAdmin() {
        return isSuperAdmin;
    }

    public void setIsSuperAdmin(Boolean isSuperAdmin) {
        this.isSuperAdmin = isSuperAdmin;
    }

    public Date getLastLogin() {
        return lastLogin;
    }

    public void setLastLogin(Date lastLogin) {
        this.lastLogin = lastLogin;
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

    @XmlTransient
    public Collection<AegisBornUserProfile> getAegisBornUserProfileCollection() {
        return aegisBornUserProfileCollection;
    }

    public void setAegisBornUserProfileCollection(Collection<AegisBornUserProfile> aegisBornUserProfileCollection) {
        this.aegisBornUserProfileCollection = aegisBornUserProfileCollection;
    }

    @XmlTransient
    public Collection<AegisBornCharacter> getAegisBornCharacterCollection() {
        return aegisBornCharacterCollection;
    }

    public void setAegisBornCharacterCollection(Collection<AegisBornCharacter> aegisBornCharacterCollection) {
        this.aegisBornCharacterCollection = aegisBornCharacterCollection;
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
        if (!(object instanceof SfGuardUser)) {
            return false;
        }
        SfGuardUser other = (SfGuardUser) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.cjrgaming.aegisborn.persistence.SfGuardUser[ id=" + id + " ]";
    }
    
}

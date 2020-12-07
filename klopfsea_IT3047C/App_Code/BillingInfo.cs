/*******************************************************************************
 * Elijah Klopfstein                                                           *
 * klopfsea@mail.uc.edu                                                        *
 * Assigment 04                                                                *
 * Due: Febuary 19th 2020                                                      *
 * IT3047C Spring 2020                                                         *
 * C# class for storing the billing information                                *
 * *****************************************************************************/

public class BillingInfo
{
    private string mName;
    private string mAddress;
    private string mPhone;
    private string mCity;
    private string mState;
    private string mZip;
    private string mCardNumber;
    private string mExpirationDate;
    private string mSecurityCode;

    /// <summary>
    /// Constructor for BillingInfo objects
    /// </summary>
    /// <param name="name">Name to be billed</param>
    /// <param name="address">Address to be billed</param>
    /// <param name="phone">Phone number of person billed</param>
    /// <param name="city">City of person billed</param>
    /// <param name="state">State of person billed</param>
    /// <param name="zip">Zip code of person billed</param>
    /// <param name="cardNumber">Card number to be billed</param>
    /// <param name="expirationDate">Card's expiration date</param>
    /// <param name="securityCode">Card's security code</param>
    public BillingInfo(string name, string address, string phone, string city, string state, string zip, string cardNumber, string expirationDate, string securityCode)
    {
        mName = name;
        mAddress = address;
        mPhone = phone;
        mCity = city;
        mState = state;
        mZip = zip;
        mCardNumber = cardNumber;
        mExpirationDate = expirationDate;
        mSecurityCode = securityCode;
    }

    /// <summary>
    /// Getter and setter for name
    /// </summary>
    public string name
    {
        get => mName;
        set => mName = value;
    }

    /// <summary>
    /// Getter and setter for address
    /// </summary>
    public string address
    {
        get => mAddress;
        set => mAddress = value;
    }

    /// <summary>
    /// Getter and setter for phone number
    /// </summary>
    public string phone
    {
        get => mPhone;
        set => mPhone = value;
    }

    /// <summary>
    /// Getter and setter for city
    /// </summary>
    public string city
    {
        get => mCity;
        set => mCity = value;
    }

    /// <summary>
    /// Getter and setter for state
    /// </summary>
    public string state
    {
        get => mState;
        set => mState = value;
    }

    /// <summary>
    /// Getter and setter for zip code
    /// </summary>
    public string zip
    {
        get => mZip;
        set => mZip = value;
    }

    /// <summary>
    /// Getter and setter for card number
    /// </summary>
    public string cardNumber
    {
        get => mCardNumber;
        set => mCardNumber = value;
    }

    /// <summary>
    /// Getter and setter for card expiration date
    /// </summary>
    public string expirationDate
    {
        get => mExpirationDate;
        set => mExpirationDate = value;
    }

    /// <summary>
    /// Getter and setter for card security code
    /// </summary>
    public string securityCode
    {
        get => mSecurityCode;
        set => mSecurityCode = value;
    }

    /// <summary>
    /// Overidden ToString method for BillingAddress objects
    /// </summary>
    /// <returns>Descriptive string</returns>
    public override string ToString()
    {
        return "Name: " + mName + " Address: " + mAddress + " Phone Number: " + mPhone +
            " City: " + mCity + " State: " + mState + " Zip Code: " + mZip + " Card Number: " +
            mCardNumber + " Expiration Date: " + mExpirationDate + " Security Code: " + mSecurityCode;
    }
}
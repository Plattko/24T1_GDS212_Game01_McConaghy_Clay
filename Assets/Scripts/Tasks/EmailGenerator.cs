using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    private static bool hasGeneratedFirstEmail = false;

    public static Email GenerateEmail()
    {
        Email email;
        if (!hasGeneratedFirstEmail) // Is onboarding email
        {
            // Generate onboarding email
            email = new Email(Strings.OnboardingEmailText);
            hasGeneratedFirstEmail = true;
        }
        else // Is task email
        {
            Task task = new Task();
            email = new Email("", task);
        }
        return email;
    }
}

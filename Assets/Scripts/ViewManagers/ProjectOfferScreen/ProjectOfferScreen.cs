using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectOfferScreen : MonoBehaviour
{
    private Project project;

    public Text header;
    public Text description;
    public Text reward;
    public Text turnaroundTime;
    public Text expectations;

    public void OfferProject(Project project)
    {
        this.project = project;
        Populate ( project );
        gameObject.SetActive ( true );
    }

    public void Populate(Project project)
    {
        header.text = project.projectName;
        description.text = project.description;
        reward.text = string.Format ( "Pays: {0}", project.reward.money );
        turnaroundTime.text = string.Format ( "Expected turnaround - {0} days", project.expectedTurnaroundInDays );
        expectations.text = string.Format ( "Requirements\nCode: {0}\nDesign: {1}", project.requirements.code, project.requirements.design );
    }

    public void AcceptProject()
    {
        EventsManager.AcceptProject ( project );
    }
}

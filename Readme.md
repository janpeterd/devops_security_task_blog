# Technology Blog made with Contentful CMS

This is a task for school. It is a (example) blog which fetches data from _Contentful CMS_ and it as a _CI/CD_ pipeline with Github Actions.

## Running my container

I automatically build a container from the newest version. To run the website:

1. Download and run container

   ```bash
   docker run . -e "Contentfuloptions__DeliveryApiKey=<your token>"  -e "Contentfuloptions__ManagementApiKey=<optional cma_access_token>" -e "Contentfuloptions__PreviewApiKey=<your key>" -e "Contentfuloptions__SpaceId=<your space ID>" -e "Contentfuloptions__UsePreviewApi=false" -e "Contentfuloptions__MaxNumberOfRateLimitRetries=0" -p 8080:80 janpeterd/aspnet-techblog
   ```

2. access it at `http://localhost:8080`

## Building own docker container

1. clone the repo: `git clone https://github.com/janpeterd/devops_security_task_blog.git`
2. cd into repo
3. `docker build . -t techblog`
4. `docker run . -e "Contentfuloptions__DeliveryApiKey=<your token>"  -e "Contentfuloptions__ManagementApiKey=<optional cma_access_token>" -e "Contentfuloptions__PreviewApiKey=<your key>" -e "Contentfuloptions__SpaceId=<your space ID>" -e "Contentfuloptions__UsePreviewApi=false" -e "Contentfuloptions__MaxNumberOfRateLimitRetries=0" -p 8080:80 techblog`
5. access it at `http://localhost:8080`

You need to set all of the **env-variables** to the keys of your contentful instance.

## Developing/ running local

1. For development/ running the application locally you can put the ENV-values in the `.env` file at project root
2. `dotnet build .`
3. `dotnet run`

```bash
# This are the env-values place them in a .env file at project root
Contentfuloptions__DeliveryApiKey="<your token>"
Contentfuloptions__ManagementApiKey="<optional cma_access_token>"
Contentfuloptions__PreviewApiKey="<your key>"
Contentfuloptions__SpaceId="<your space ID>"
Contentfuloptions__UsePreviewApi=false
Contentfuloptions__MaxNumberOfRateLimitRetries=0
```

- edit for demo
